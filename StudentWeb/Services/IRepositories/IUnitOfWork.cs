namespace StudentWeb.Services.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Student { get; }
        IClassRepository Class { get; }
        Task SaveChangesAsync();
    }
}
