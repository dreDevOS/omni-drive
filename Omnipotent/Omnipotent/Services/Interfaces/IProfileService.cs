using Omnipotent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Services.Interfaces
{
    public  interface IProfileService
    {
        Task<Customer> GetProfile(Guid id, string token);
        Task<Customer> UpdateProfile(Guid id, Customer profile, string token);
        Task<bool> CreateProfile(Customer profile);

    }
}
