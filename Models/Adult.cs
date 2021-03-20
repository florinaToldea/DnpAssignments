using System.ComponentModel.DataAnnotations;

namespace DnpAssignments.Models
{
    public class Adult : Person
    {
        public Job JobTitle { get; set; }
    }
}