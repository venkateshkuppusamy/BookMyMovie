using System.Runtime.InteropServices;

namespace BookMyMovie.TenantMgmt.API.Business.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<PaginatedList<T>> GetAllAsync(PaginationParameters parameters);
        Task<T?> GetByIdAsync(int id);
        Task<int> CreateAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }
}
