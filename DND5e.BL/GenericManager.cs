using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND5e.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<DND5eEntities> options;
    }
}
