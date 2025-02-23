namespace BookMyMovie.TenantMgmt.API.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<PaginatedList<T>> GetAllAsync(PaginationParameters parameters);
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
