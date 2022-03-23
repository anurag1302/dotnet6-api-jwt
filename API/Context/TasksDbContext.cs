using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class TasksDbContext:DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options):base(options)
        {

        }

        public DbSet<API.Entities.Task> Tasks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
