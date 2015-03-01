using System;
using System.Linq;
using System.Threading.Tasks;
using ScrumChores.Model.Entities;

namespace ScrumChores.Model.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User newUser);

        Task<User> GetUser(Guid userID);

        Task<UserType> CreateUserType(UserType newUserType);

        Task<UserType> GetUserType(UserType newUserType);

        Task<UserType> GetUserType(Guid userTypeID);

        Task<UserType> GetUserType(string userTypeDesc);
    }
}