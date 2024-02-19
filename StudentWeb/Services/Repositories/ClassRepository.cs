
using StudentWeb.Data.Access;
using StudentWeb.Models;
using StudentWeb.Services.IRepositories;

namespace StudentWeb.Services.Repositories
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
