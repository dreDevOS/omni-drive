using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Settings.Interfaces
{
     public interface IRuntimeContext
    {

        string BaseEndpoint { get; set; }
        string Token { get; set; }
        Guid UserId { get; set; }

        void RemoveToken();
        void RemoveUserId();

    }
}
