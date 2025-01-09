using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND5e.PL.Entities
{
    public class tblSkill
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public bool Proficiency { get; set; }
        public bool Expertise { get; set; }
    }
}
