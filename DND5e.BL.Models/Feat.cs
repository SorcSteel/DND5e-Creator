using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND5e.BL.Models
{
    public class Feat
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
