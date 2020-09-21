using blogBukov.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBukov.Domain.Model
{
    public class BlogPost : Entity
    {

        public Employee Owner { get; set; }

        public DateTime Created { get; set; }

        public string Title { get; set; }

        public string Data { get; set; }
    }
}
