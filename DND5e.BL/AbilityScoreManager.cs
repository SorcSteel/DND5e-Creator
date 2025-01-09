

namespace DND5e.BL
{
    public class AbilityScoreManager : GenericManager<tblAbilityScore>
    {

        public AbilityScoreManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(AbilityScore abilityScore, bool rollback = false)
        {
            try
            {
                tblAbilityScore row = new tblAbilityScore { Description = abilityScore.Description };
                abilityScore.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AbilityScore> Load()
        {

            try
            {
                List<AbilityScore> rows = new List<AbilityScore>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new AbilityScore
                        {
                            Id = d.Id,
                            Description = d.Description,
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public AbilityScore LoadById(Guid id)
        {
            try
            {
                tblAbilityScore row = base.LoadById(id);

                if (row != null)
                {
                    AbilityScore abilityScore = new AbilityScore
                    {
                        Id = row.Id,
                        Description = row.Description,
                    };

                    return abilityScore;
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

        public int Update(AbilityScore abilityScore, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblAbilityScore
                {
                    Id = abilityScore.Id,
                    Description = abilityScore.Description
                }, rollback);
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
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
}
