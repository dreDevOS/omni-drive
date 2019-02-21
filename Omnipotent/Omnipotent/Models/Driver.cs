using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Models
{
    public class Driver : User
    {

        public bool Occupied { get; set; }
        public Car Car { get; set; }
        public Location Location { get; set; }
    }
}
