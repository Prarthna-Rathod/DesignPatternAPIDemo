
using DemoApplication.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Infra.Domain
{
    public class StudResultDBContext : DbContext
    {
        public StudResultDBContext(DbContextOptions<StudResultDBContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<Result> results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new List<Student> {
                new Student(1,"prarthna"),
                new Student(2,"nidhi"),
                new Student(3,"deep")
            });
        }
    }
}
