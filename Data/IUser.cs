using System.Threading.Tasks;
using DnpAssignments.Models;

namespace DnpAssignments.Data
{
    public interface IUser
    {
        Task<User> ValidateLoginAsync(string username, string password);
       
    }
}