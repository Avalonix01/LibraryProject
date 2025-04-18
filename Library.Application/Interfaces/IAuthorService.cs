using Library.Application.Dtos.AuthorDtos;

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task<AuthorDto> AddAsync(AuthorDto authorDto);
        Task UpdateAsync(AuthorDto authorDto);
        Task DeleteAsync(int id);   
    }
}
