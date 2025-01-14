

namespace DND5e.BL
{
    public class SaveManager : GenericManager<tblSave>
    {

        public SaveManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(Save save, bool rollback = false)
        {
            try
            {
                tblSave row = new tblSave 
                { 
                    CharacterId = save.CharacterId,
                    Str = save.Str,
                    Dex = save.Dex,
                    Con = save.Con,
                    Int = save.Int,
                    Wis = save.Wis,
                    Cha = save.Cha

                };
                save.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Save> Load()
        {

            try
            {
                List<Save> rows = new List<Save>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Save
                        {
                            Id = d.Id,
                            CharacterId = d.CharacterId,
                            Str = d.Str,
                            Dex = d.Dex,
                            Con = d.Con,
                            Int = d.Int,
                            Wis = d.Wis,
                            Cha = d.Cha

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Save LoadById(int id)
        {
            try
            {
                tblSave row = base.LoadById(id);

                if (row != null)
                {
                    Save save = new Save
                    {
                        Id = row.Id,
                        CharacterId = row.CharacterId,
                        Str = row.Str,
                        Dex = row.Dex,
                        Con = row.Con,
                        Int = row.Int,
                        Wis = row.Wis,
                        Cha = row.Cha
                    };

                    return save;
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

        public int Update(Save save, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblSave
                {
                    Id = save.Id,
                    CharacterId = save.CharacterId,
                    Str = save.Str,
                    Dex = save.Dex,
                    Con = save.Con,
                    Int = save.Int,
                    Wis = save.Wis,
                    Cha = save.Cha

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

