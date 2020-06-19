using System.ComponentModel.DataAnnotations;

namespace ApiToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Concluded { get; set; } = false;
        public User User { get; set; }
        public int IdUser { get; set; }
    }
}