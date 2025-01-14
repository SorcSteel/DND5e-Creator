

namespace DND5e.BL
{
    public class EquipmentManager : GenericManager<tblEquipment>
    {

        public EquipmentManager(DbContextOptions<DND5eEntities> options) : base(options) { }

        public int Insert(Equipment equipment, bool rollback = false)
        {
            try
            {
                tblEquipment row = new tblEquipment 
                { 
                    CharacterId = equipment.CharacterId,
                    Name = equipment.Name,
                    Amount = equipment.Amount,
                    Description = equipment.Description
                };
                equipment.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Equipment> Load()
        {

            try
            {
                List<Equipment> rows = new List<Equipment>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Equipment
                        {
                            Id = d.Id,
                            CharacterId = d.CharacterId,
                            Name = d.Name,
                            Amount = d.Amount,
                            Description = d.Description

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Equipment LoadById(int id)
        {
            try
            {
                tblEquipment row = base.LoadById(id);

                if (row != null)
                {
                    Equipment equipment = new Equipment
                    {
                        Id = row.Id,
                        CharacterId = row.CharacterId,
                        Name = row.Name,
                        Amount = row.Amount,
                        Description = row.Description
                    };

                    return equipment;
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

        public int Update(Equipment equipment, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblEquipment
                {
                    Id = equipment.Id,
                    CharacterId = equipment.CharacterId,
                    Name = equipment.Name,
                    Amount = equipment.Amount,
                    Description = equipment.Description

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

