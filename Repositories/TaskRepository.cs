using ApiToDoList.Database;
using ApiToDoList.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiToDoList.Repositories
{
    public class TaskRepository
    {
        private readonly ApplicationDBContext _context;
        public TaskRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Task> Get()
        {
            return _context.Tasks.Select(x =>
                new Task
                {
                    Id = x.Id,
                    Description = x.Description,
                    Concluded = x.Concluded,
                    IdUser = x.IdUser,
                    User = new User
                    {
                        Name = x.User.Name,
                        Id = x.User.Id
                    }
                }).ToList();
        }

        public void Create(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(Task task)
        {
            var editTask = _context.Tasks.Where(x => x.Id == task.Id).FirstOrDefault();
            editTask.Description = !string.IsNullOrEmpty(task.Description) ? task.Description : editTask.Description;
            editTask.IdUser = task.IdUser != 0 ? task.IdUser : editTask.IdUser;
            _context.SaveChanges();
        }

        public void Delete(Task task)
        {
            var deleteTask = _context.Tasks.Where(x => x.Id == task.Id).FirstOrDefault();
            _context.Remove(deleteTask);
            _context.SaveChanges();
        }

        public void ChangeState(Task task)
        {
            var editTask = _context.Tasks.Where(x => x.Id == task.Id).FirstOrDefault();
            editTask.Concluded = task.Concluded;
            _context.SaveChanges();
        }

    }
}