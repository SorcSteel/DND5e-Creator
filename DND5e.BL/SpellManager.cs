

namespace DND5e.BL
{
    public class SpellManager : GenericManager<tblSpell>
    {

        public SpellManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(Spell spell, bool rollback = false)
        {
            try
            {
                tblSpell row = new tblSpell 
                { 
                    CharacterId = spell.CharacterId,
                    First = spell.First,
                    Second = spell.Second,
                    Third = spell.Third,
                    Fourth = spell.Fourth,
                    Fifth = spell.Fifth,
                    Sixth = spell.Sixth,
                    Seventh = spell.Seventh,
                    Eighth = spell.Eighth,
                    Ninth = spell.Ninth
                };
                spell.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Spell> Load()
        {

            try
            {
                List<Spell> rows = new List<Spell>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Spell
                        {
                            Id = d.Id,
                            CharacterId = d.CharacterId,
                            First = d.First,
                            Second = d.Second,
                            Third = d.Third,
                            Fourth = d.Fifth,
                            Fifth = d.Fifth,
                            Sixth = d.Sixth,
                            Seventh = d.Seventh,
                            Eighth = d.Eighth,
                            Ninth = d.Ninth

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Spell LoadById(int id)
        {
            try
            {
                tblSpell row = base.LoadById(id);

                if (row != null)
                {
                    Spell spell = new Spell
                    {
                        Id = row.Id,
                        CharacterId = row.CharacterId,
                        First = row.First,
                        Second = row.Second,
                        Third = row.Third,
                        Fourth = row.Fifth,
                        Fifth = row.Fifth,
                        Sixth = row.Sixth,
                        Seventh = row.Seventh,
                        Eighth = row.Eighth,
                        Ninth = row.Ninth

                    };

                    return spell;
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

        public int Update(Spell spell, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblSpell
                {
                    Id = spell.Id,
                    CharacterId = spell.CharacterId,
                    First = spell.First,
                    Second = spell.Second,
                    Third = spell.Third,
                    Fourth = spell.Fifth,
                    Fifth = spell.Fifth,
                    Sixth = spell.Sixth,
                    Seventh = spell.Seventh,
                    Eighth = spell.Eighth,
                    Ninth = spell.Ninth

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

