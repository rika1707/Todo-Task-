using Microsoft.EntityFrameworkCore;
using TaskWebApi.Models;

namespace TaskWebApi.Context
{
    public class TaskDbContext:DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todos> Todos { get; set; }
    }
}
