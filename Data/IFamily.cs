using System.Collections.Generic;
using DnpAssignments.Models;

namespace DnpAssignments.Data
{
    public interface IFamily
    {
        public IList<Family> GetAllFamilies();
        void AddFamily(Family family);
        void RemoveFamily(Family family);
    }
}