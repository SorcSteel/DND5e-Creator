using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DND5e.BL
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message) { }
        public AlreadyExistsException() : base("Row already exists.") { }
    }
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<DND5eEntities> options;
        protected readonly ILogger logger;

        public GenericManager(DbContextOptions<DND5eEntities> options)
        {
            this.options = options;
        }

        public GenericManager(ILogger logger,
                              DbContextOptions<DND5eEntities> options)
        {
            this.options = options;
            this.logger = logger;
        }

        public GenericManager() { }

        public List<T> Load()
        {
            try
            {
                if (logger != null) logger.LogWarning($"Get {typeof(T).Name}s");
                return new DND5eEntities(options)
                    .Set<T>()
                    .ToList<T>()
                    .OrderBy(x => x.Id)
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> Load(string storedproc)
        {
            try
            {
                return new DND5eEntities(options)
                    .Set<T>()
                    .FromSqlRaw($"exec {storedproc}")
                    .ToList<T>()
                    .OrderBy(x => x.Id)
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> Load(string storedproc, string value)
        {
            try
            {
                return new DND5eEntities(options)
                    .Set<T>()
                    .FromSqlRaw($"exec {storedproc} {value}")
                    .ToList<T>()
                    .OrderBy(x => x.Id)
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public T LoadById(int id)
        {
            try
            {
                var row = new DND5eEntities(options).Set<T>().Where(t => t.Id == id).FirstOrDefault();
                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Insert(T entity,
                          Expression<Func<T, bool>> predicate = null,
                          bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DND5eEntities dc = new DND5eEntities(options))
                {
                    if ((predicate == null) || ((predicate != null) && (!dc.Set<T>().Any(predicate))))
                    {
                        IDbContextTransaction dbTransaction = null;
                        if (rollback) dbTransaction = dc.Database.BeginTransaction();

                        entity.Id = Guid.NewGuid();

                        dc.Set<T>().Add(entity);
                        results = dc.SaveChanges();

                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        if (logger != null) logger.LogWarning("Row already exists. {UserId}", "bfoote");
                        throw new Exception("Row already exists.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> InsertAsync(T entity,
                                            Expression<Func<T, bool>> predicate = null,
                                            bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DND5eEntities dc = new DND5eEntities(options))
                {
                    if ((predicate == null) || ((predicate != null) && (!dc.Set<T>().Any(predicate))))
                    {
                        IDbContextTransaction dbTransaction = null;
                        if (rollback) dbTransaction = dc.Database.BeginTransaction();

                        entity.Id = Guid.NewGuid();

                        dc.Set<T>().Add(entity);
                        results = dc.SaveChanges();

                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        if (logger != null) logger.LogWarning("Row already exists. {UserId}", "bfoote");
                        throw new AlreadyExistsException("That row already exists.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity,
                         bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DND5eEntities dc = new DND5eEntities(options))
                {

                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();


                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Update(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DND5eEntities dc = new DND5eEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    dc.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DND5eEntities dc = new DND5eEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(t => t.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
