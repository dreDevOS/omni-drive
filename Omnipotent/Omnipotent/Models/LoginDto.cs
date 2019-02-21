using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Models
{
     public class LoginDto
    {
        public string AccessToken { get; set; }
        public Customer User { get; set; }
    }
}
