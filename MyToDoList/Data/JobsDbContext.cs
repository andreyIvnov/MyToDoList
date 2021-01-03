using Microsoft.EntityFrameworkCore;
using MyToDoList.Model;
using System;

namespace MyToDoList.Data
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(new Job {
                ID=1,
                Title="Wash the Car",
                IsDone = false,
                DueDate = new DateTime(2022,3,15)
            },
            new Job
            {
                ID = 2,
                Title = "Do Home Work",
                IsDone = false,
                DueDate = new DateTime(2019, 5, 5)
            });
        }
    }
}
