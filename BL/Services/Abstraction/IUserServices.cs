using Dal.Entities;
using Dal.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstraction
{
    public interface IUserServices
    {
        public User AuthenticateUser(string username, string password);
        string HashPassword(string password);
    }
}
