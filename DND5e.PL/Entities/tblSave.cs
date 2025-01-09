using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND5e.PL.Entities
{
    public class tblSave
    {
        public int CharacterId { get; set; }
        public bool Str { get; set; }
        public bool Dex { get; set; }
        public bool Con { get; set; }
        public bool Int { get; set; }
        public bool Wis { get; set; }
        public bool Cha { get; set; }
    }
}
