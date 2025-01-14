

namespace DND5e.BL
{
    public class FeatManager : GenericManager<tblFeat>
    {

        public FeatManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(Feat feat, bool rollback = false)
        {
            try
            {
                tblFeat row = new tblFeat 
                { 
                    CharacterId = feat.CharacterId,
                    Title = feat.Title,
                    Description = feat.Description
                };
                feat.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Feat> Load()
        {

            try
            {
                List<Feat> rows = new List<Feat>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Feat
                        {
                            Id = d.Id,
                            CharacterId = d.CharacterId,
                            Title = d.Title,
                            Description = d.Description

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Feat LoadById(int id)
        {
            try
            {
                tblFeat row = base.LoadById(id);

                if (row != null)
                {
                    Feat feat = new Feat
                    {
                        Id = row.Id,
                        CharacterId = row.CharacterId,
                        Title = row.Title,
                        Description = row.Description
                    };

                    return feat;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Feat feat, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblFeat
                {
                    Id = feat.Id,
                    CharacterId = feat.CharacterId,
                    Title = feat.Title,
                    Description = feat.Description
                }, rollback);
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(int id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

