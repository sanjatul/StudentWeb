using Microsoft.EntityFrameworkCore;
using StudentWeb.Data.Access;
using StudentWeb.Models;
using StudentWeb.Services.IRepositories;

namespace StudentWeb.Services.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
