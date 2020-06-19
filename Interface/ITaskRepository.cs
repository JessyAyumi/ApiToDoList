using System.Collections.Generic;
using ApiToDoList.Models;

namespace ApiToDoList.Interface
{
    public interface ITaskRepository
    {
        IEnumerable<Task> Get();
        void Create(Task task);
        void Update(Task task);
        void Delete(Task task);
        void ChangeState(Task task);
    }
}