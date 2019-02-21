using Omnipotent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Services.Interfaces
{
      public interface IDriveServices
    {
        Task<IEnumerable<Drive>> GetAllDrives(Guid id, string token);
        Task<Drive> GetDrive(Guid id, string token);
        Task<bool> CreateDrive(string token, Drive drive);
        Task<bool> QuitDrive(string token, Drive drive);
        Task<bool> EditDrive(Guid id, string token, Drive drive);
        Task<bool> CommentDrive(Guid id, string token, CommentDto jObject);


    }
}
