using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Omnipotent.Models
{
   public class Drive : BindableObject 
    {
        internal readonly object Address;

        public Guid DriveId { get; set; }
        public DateTime Date { get; set; }
        public Enums.CarTypes CarType { get; set; }
        public Customer OrderedBy { get; set; }
        public Dispatcher ApproveBy { get; set; }
        public Driver DriveBy { get; set; }
        public Comment Comments { get; set; }
        public Enums.Status State { get; set; }
        public object Price { get; internal set; }
        public object Destination { get; internal set; }
    }
}
