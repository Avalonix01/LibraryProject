using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author?> GetByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAsync();
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
