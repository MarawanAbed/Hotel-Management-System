using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repo.Abstraction
{
    public interface IUserRepo
    {
        public User Login(string username, string Hashpassword);

    }
}
