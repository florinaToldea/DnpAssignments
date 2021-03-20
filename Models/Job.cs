using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DnpAssignments.Models
{
    public class Job
    {
        [Required]
        public string JobTitle { get; set; }
        
        [Required]
        public int Salary { get; set; }
    }
}