using System.Collections.Generic;
using DnpAssignments.Models;
using DnpAssignments.Persistance;

namespace DnpAssignments.Data.Impl
{
    public class FamilyService : IFamily
    {
        private FileContext fileContext = new FileContext();
        private List<Family> families;

        public IList<Family> GetAllFamilies()
        {
            return fileContext.Families;
        }

        public void AddFamily(Family family)
        {
            families.Add(family);
            fileContext.SaveChanges();
        }

        public void RemoveFamily(Family family)
        {
            families.Remove(family);
            fileContext.SaveChanges();
        }
    }
}