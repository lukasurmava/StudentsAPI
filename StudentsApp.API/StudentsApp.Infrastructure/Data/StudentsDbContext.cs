using Microsoft.EntityFrameworkCore;
using StudentsApp.Domain;

namespace StudentsApp.Infrastructure.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}