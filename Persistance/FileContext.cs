using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DnpAssignments.Models;

namespace DnpAssignments.Persistance
{
    public class FileContext
    {
        public IList<Family> Families { get; set; }
        public IList<Adult> Adults { get;  set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
            
            //adding a new adult.
            
        }

        public void addAdult(Adult adult)
        {
            Adults.Add(adult);
            SaveChanges();
        }

        public void removeAdult(int id)
        {
            Adult toRemove = Adults.FirstOrDefault(a => a.Id == id);
            Adults.Remove(toRemove);
            SaveChanges();
        }
    }
}