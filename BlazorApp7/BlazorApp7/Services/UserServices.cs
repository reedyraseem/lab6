using BlazorApp7.Data;
using BlazorApp7.Services;
using Microsoft.AspNetCore.Components;
using System;
namespace BlazorApp7.Services
{
   

public class UserServices : IUserService
    {
        private List<User> _users = new List<User>();

        public List<User> GetUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void EditUser(User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
            }
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
            }
        }

        User IUserService.GetUserByNameAndEmail(string name, string email)
        {
            return new User
            {
                Id = 1,
                Name = name,
                Email = email,
                BorrowedBooks = new List<Book>()
            };
        }
        public User GetUserByName(string userName)
        {
            return _users.FirstOrDefault(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
