using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBukov.Domain.Model.Common
{
    public abstract class Entity
    {
        protected Entity()
        { }

        public virtual long Id { get; set; }
    }
}
