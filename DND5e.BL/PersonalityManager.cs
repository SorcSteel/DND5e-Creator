

namespace DND5e.BL
{
    public class PersonalityManager : GenericManager<tblPersonality>
    {

        public PersonalityManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(Personality personality, bool rollback = false)
        {
            try
            {
                tblPersonality row = new tblPersonality 
                { 
                    CharacterId = personality.CharacterId,
                    Type = personality.Type,
                    Description = personality.Description
                };
                personality.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Personality> Load()
        {

            try
            {
                List<Personality> rows = new List<Personality>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Personality
                        {
                            Id = d.Id,
                            CharacterId = d.CharacterId,
                            Type = d.Type,
                            Description = d.Description

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Personality LoadById(int id)
        {
            try
            {
                tblPersonality row = base.LoadById(id);

                if (row != null)
                {
                    Personality personality = new Personality
                    {
                        Id = row.Id,
                        CharacterId = row.CharacterId,
                        Type = row.Type,
                        Description = row.Description
                    };

                    return personality;
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

        public int Update(Personality personality, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblPersonality
                {
                    Id = personality.Id,
                    CharacterId = personality.CharacterId,
                    Type = personality.Type,
                    Description = personality.Description

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

