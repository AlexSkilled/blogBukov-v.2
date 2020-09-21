using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBukov.Domain.Model
{
    public class User : IdentityUser<int>
    {
        
        public Employee Employee { get; set; }
    }
}
