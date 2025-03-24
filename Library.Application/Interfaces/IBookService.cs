using Library.Application.Dtos.BookDtos;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task AddAsync(BookDto bookDto);
        Task UpdateAsync(BookDto bookDto);
        Task DeleteAsync(int id);
    }
}
