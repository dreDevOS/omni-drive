using Omnipotent.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Settings
{
    public class RuntimeContext : IRuntimeContext
    {
        public string BaseEndpoint

        { get => AppSettings.BaseEndpoint;

          set => AppSettings.BaseEndpoint= value;

        }


        public string Token

        { get => AppSettings.Token;

            set => AppSettings.Token = value;
        }
        

        public Guid UserId

        { get => AppSettings.UserId;

          set => AppSettings.UserId= value;
        }

        public void RemoveToken()
        {
            AppSettings.RemoveToken();
        }

        public void RemoveUserId()
        {
            AppSettings.RemoveUserId();
        }
    }
}
