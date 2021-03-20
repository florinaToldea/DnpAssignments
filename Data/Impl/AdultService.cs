using System.Collections.Generic;
using System.Linq;
using DnpAssignments.Models;
using DnpAssignments.Persistance;

namespace DnpAssignments.Data.Impl
{
    public class AdultService : IAdult
    {
        private FileContext fileContext;
        
        public AdultService()
        {
            fileContext = new FileContext();
        }

        public IList<Adult> GetAllAdults()
        {
            return fileContext.Adults;
        }

        public void AddAdult(Adult adult)
        {
            IList<Adult> adults = fileContext.Adults;
            int maxId = adults.Max(a => a.Id);
            maxId++;
            adult.Id = maxId;
            fileContext.addAdult(adult);
        }

        public void RemoveAdult(int id)
        {
            fileContext.removeAdult(id);
        }

     
    }
}