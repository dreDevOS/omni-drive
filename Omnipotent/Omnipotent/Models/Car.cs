using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Models
{
   public class Car
    {
        public Driver MyDriver { get; set; }
        public int ModelYear { get; set; }
        public string RegNumber { get; set; }
        public int CarId { get; set; }
        public Enums.CarTypes Type { get; set; }
    }
}
