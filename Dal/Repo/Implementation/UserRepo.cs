using Dal.Entities;
using Dal.Repo.Abstraction;
using HotelManagementSystem.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public User Login(string username, string Hashpassword) 
            => _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == Hashpassword);


        


    }
}
