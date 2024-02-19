using Microsoft.EntityFrameworkCore;
using StudentWeb.Models;

namespace StudentWeb.Data.Access
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Class> Class { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
