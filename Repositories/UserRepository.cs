using System.Collections.Generic;
using System.Linq;
using ApiToDoList.Database;
using ApiToDoList.Interface;
using ApiToDoList.Models;

namespace ApiToDoList.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public User Get(User model)
        {
            return _context.Users.FirstOrDefault(x => x.Name == model.Name && x.Password == model.Password);
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}