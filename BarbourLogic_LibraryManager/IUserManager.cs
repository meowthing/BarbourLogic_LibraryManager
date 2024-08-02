using BarbourLogic_LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbourLogic_LibraryManager
{
    public interface IUserManager
    {
        public void CreateUser(User user);
        public User GetUser(int id);

        public void EditUser(int id);

        public void DeleteUser(int id);

    }
}
