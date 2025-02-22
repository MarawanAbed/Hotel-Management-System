using BL.Services.Abstraction;
using Dal.Entities;
using Dal.Repo.Abstraction;
using Dal.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepo _userRepository;

        public UserServices(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }
        public User AuthenticateUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            return _userRepository.Login(username, hashedPassword);
        }
            
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
