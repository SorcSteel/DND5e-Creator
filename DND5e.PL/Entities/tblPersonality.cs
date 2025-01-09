using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND5e.PL.Entities
{
    internal class tblPersonality
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
