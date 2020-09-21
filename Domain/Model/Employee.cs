using blogBukov.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBukov.Domain.Model
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string FullName 
        {
            get => FirstName + " " + Surname;    
        }
        

    }
}
