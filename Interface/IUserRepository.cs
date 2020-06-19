using System.Collections.Generic;
using ApiToDoList.Models;

namespace ApiToDoList.Interface
{
    public interface IUserRepository
    {
        User Get(User model);
        void Create(User user);
    }
}