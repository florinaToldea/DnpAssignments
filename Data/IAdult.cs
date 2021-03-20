using System.Collections.Generic;
using DnpAssignments.Models;

namespace DnpAssignments.Data
{
    public interface IAdult
    {
        IList<Adult> GetAllAdults();
        void AddAdult(Adult adult);
        void RemoveAdult(int id);

      
    }
}