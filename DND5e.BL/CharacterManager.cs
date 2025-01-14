

namespace DND5e.BL
{
    public class CharacterManager : GenericManager<tblCharacter>
    {

        public CharacterManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(Character character, bool rollback = false)
        {
            try
            {
                tblCharacter row = new tblCharacter 
                { 
                    UserId = character.UserId,
                    Name = character.Name,
                    Race = character.Race,
                    Level = character.Level,
                    Class = character.Class,
                    Alignment = character.Alignment,
                    Background = character.Background,
                    ExperiencePoints = character.ExperiencePoints,
                    HitDie = character.HitDie,
                    MaxHp = character.MaxHp,
                    CurrentHp = character.CurrentHp,
                    TempHp = character.TempHp,
                    Ac = character.Ac,
                    Initiative = character.Initiative,
                    ProficiencyBonus = character.ProficiencyBonus,
                    Speed = character.Speed,
                };
                character.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Character> Load()
        {

            try
            {
                List<Character> rows = new List<Character>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Character
                        {
                            Id = d.Id,
                            UserId = d.UserId,
                            Name = d.Name,
                            Race = d.Race,
                            Level = d.Level,
                            Class = d.Class,
                            Alignment = d.Alignment,
                            Background = d.Background,
                            ExperiencePoints = d.ExperiencePoints,
                            HitDie = d.HitDie,
                            MaxHp = d.MaxHp,
                            CurrentHp = d.CurrentHp,
                            TempHp = d.TempHp,
                            Ac = d.Ac,
                            Initiative = d.Initiative,
                            Speed= d.Speed

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Character LoadById(int id)
        {
            try
            {
                tblCharacter row = base.LoadById(id);

                if (row != null)
                {
                    Character character = new Character
                    {
                        Id = row.Id,
                        UserId = row.UserId,
                        Name = row.Name,
                        Race = row.Race,
                        Level = row.Level,
                        Class = row.Class,
                        Alignment = row.Alignment,
                        Background = row.Background,
                        ExperiencePoints = row.ExperiencePoints,
                        HitDie = row.HitDie,
                        MaxHp = row.MaxHp,
                        CurrentHp = row.CurrentHp,
                        TempHp = row.TempHp,
                        Ac = row.Ac,
                        Initiative = row.Initiative,
                        Speed= row.Speed

                    };

                    return character;
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

        public int Update(Character character, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblCharacter
                {
                    Id = character.Id,
                    UserId = character.UserId,
                    Name = character.Name,
                    Race = character.Race,
                    Level = character.Level,
                    Class = character.Class,
                    Alignment = character.Alignment,
                    Background = character.Background,
                    ExperiencePoints = character.ExperiencePoints,
                    HitDie = character.HitDie,
                    MaxHp = character.MaxHp,
                    CurrentHp = character.CurrentHp,
                    TempHp = character.TempHp,
                    Ac = character.Ac,
                    Initiative = character.Initiative,
                    Speed = character.Speed

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
}
