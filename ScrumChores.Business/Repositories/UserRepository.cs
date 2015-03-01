using ScrumChores.Business.Context;
using ScrumChores.Model.Entities;
using ScrumChores.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumChores.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ScrumChoresDbContext _context = new ScrumChoresDbContext();

        public async Task<User> CreateUser(User newUser)
        {
            var userType = GetUserType("User").Result;

            if (userType != null)
                newUser.UserType = userType;

            var result = _context.Users.Add(newUser);
            
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<UserType> CreateUserType(UserType newUserType)
        {
            var result = _context.UserTypes.Add(newUserType);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<UserType> GetUserType(UserType newUserType)
        {
            var result = _context.UserTypes.Where(x => x.UserTypeID == newUserType.UserTypeID).FirstOrDefault();

            return result;
        }

        public async Task<UserType> GetUserType(Guid userTypeID)
        {
            var result = _context.UserTypes.Where(x => x.UserTypeID == userTypeID).FirstOrDefault();

            return result;
        }

        public async Task<UserType> GetUserType(string userTypeDesc)
        {
            var result = _context.UserTypes.Where(x => x.Description == userTypeDesc).FirstOrDefault();

            return result;
        }
        
        public async Task<User> GetUser(Guid userID)
        {
            var result = _context.Users.Where(x => x.UserID == userID).FirstOrDefault();

            return result;
        }
    }
}
