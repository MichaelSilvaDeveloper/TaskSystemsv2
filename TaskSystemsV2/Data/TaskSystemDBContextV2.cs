using Microsoft.EntityFrameworkCore;
using TaskSystemsV2.Data.Map;
using TaskSystemsV2.Models;

namespace TaskSystemsV2.Data
{
    public class TaskSystemDBContextV2 : DbContext
    {
        public TaskSystemDBContextV2(DbContextOptions<TaskSystemDBContextV2> options) : base(options)
        {        
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}