

namespace DND5e.BL
{
    public class SkillManager : GenericManager<tblSkill>
    {

        public SkillManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(Skill skill, bool rollback = false)
        {
            try
            {
                tblSkill row = new tblSkill 
                { 
                    CharacterId = skill.CharacterId,
                    Name = skill.Name,
                    Proficiency = skill.Proficiency,
                    Expertise = skill.Expertise

                };
                skill.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Skill> Load()
        {

            try
            {
                List<Skill> rows = new List<Skill>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Skill
                        {
                            Id = d.Id,
                            CharacterId = d.CharacterId,
                            Name = d.Name,
                            Proficiency = d.Proficiency,
                            Expertise = d.Expertise

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Skill LoadById(int id)
        {
            try
            {
                tblSkill row = base.LoadById(id);

                if (row != null)
                {
                    Skill skill = new Skill
                    {
                        Id = row.Id,
                        CharacterId = row.CharacterId,
                        Name = row.Name,
                        Proficiency = row.Proficiency,
                        Expertise = row.Expertise
                    };

                    return skill;
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

        public int Update(Skill skill, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblSkill
                {
                    Id = skill.Id,
                    CharacterId = skill.CharacterId,
                    Name = skill.Name,
                    Proficiency = skill.Proficiency,
                    Expertise = skill.Expertise
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

