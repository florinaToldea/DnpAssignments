using System.Collections.Generic;
using System.Threading.Tasks;
using DnpAssignments.Models;

namespace DnpAssignments.Data
{
    public interface IAdult
    {
        Task<IList<Adult>> GetAllAdultsAsync();
        Task<Adult> GetAdultAsync(int id);
        Task AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int id);


    }
}