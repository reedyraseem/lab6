using BlazorApp7.Data;
using System.Collections.Generic;
namespace BlazorApp7.Services
{
   

    public interface IUserService
    {
        List<User> GetUsers();
        void AddUser(User user);
        void EditUser(User updatedUser);
        void DeleteUser(int userId);
        User GetUserByNameAndEmail(string name, string email);
        User GetUserByName(string userName);
    }

}
