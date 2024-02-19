using System.Linq.Expressions;

namespace StudentWeb.Services.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<IEnumerable<T>> GetAllAsync(string includeProperties = "",Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = "");
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
