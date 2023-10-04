using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Models;

namespace StudentManagementApp
{
    public class StudentManagementDbContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=StudentManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
