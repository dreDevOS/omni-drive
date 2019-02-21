using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Services.Interfaces
{
   public interface IAuthenticationService
    {
        Task<bool> Login(string userName, string password);
        Task<bool> Logout();
    }
}
