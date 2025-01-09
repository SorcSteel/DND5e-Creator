using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND5e.PL.Entities
{
    public class tblCharacter
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int Level { get; set; }
        public string Class { get; set; }
        public string Alignment { get; set; }
        public string Background { get; set; }
        public int ExperiencePoints { get; set; }
        public string HitDie { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int TempHp { get; set; }
        public int Ac { get; set; }
        public int Initiative { get; set; }
        public int ProficiencyBonus { get; set; }
        public int Speed { get; set; }
    }
}
