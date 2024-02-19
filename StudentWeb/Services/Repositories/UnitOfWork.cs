using StudentWeb.Data.Access;
using StudentWeb.Services.IRepositories;

namespace StudentWeb.Services.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Student { get; private set; }
        public IClassRepository Class { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Student = new StudentRepository(_context);
            Class = new ClassRepository(_context);
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
