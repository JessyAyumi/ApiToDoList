using ApiToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiToDoList.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().HasKey(x => x.Id);
            modelbuilder.Entity<Task>().HasKey(x => x.Id);
            modelbuilder.Entity<User>().HasMany(x => x.Task).WithOne(x => x.User).HasForeignKey(x => x.IdUser);
            modelbuilder.Entity<Task>().HasOne(x => x.User).WithMany(x => x.Task).HasForeignKey(x => x.IdUser);
        }
    }
}