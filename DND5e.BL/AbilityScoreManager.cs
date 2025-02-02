﻿

namespace DND5e.BL
{
    public class AbilityScoreManager : GenericManager<tblAbilityScore>
    {

        public AbilityScoreManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(AbilityScore abilityScore, bool rollback = false)
        {
            try
            {
                tblAbilityScore row = new tblAbilityScore 
                { 
                    CharacterId = abilityScore.CharacterId,
                    Str = abilityScore.Str,
                    Dex = abilityScore.Dex,
                    Con = abilityScore.Con,
                    Int = abilityScore.Int,
                    Wis = abilityScore.Wis,
                    Cha = abilityScore.Cha
                };
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

        public AbilityScore LoadById(int id)
        {
            try
            {
                tblAbilityScore row = base.LoadById(id);

                if (row != null)
                {
                    AbilityScore abilityScore = new AbilityScore
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
                    CharacterId = abilityScore.CharacterId,
                    Str = abilityScore.Str,
                    Dex = abilityScore.Dex,
                    Con = abilityScore.Con,
                    Int = abilityScore.Int,
                    Wis = abilityScore.Wis,
                    Cha = abilityScore.Cha
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

