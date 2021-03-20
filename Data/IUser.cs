using DnpAssignments.Models;

namespace DnpAssignments.Data
{
    public interface IUser
    {
        User ValidateUser(string username, string password);
       
    }
}