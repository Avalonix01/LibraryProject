
using Library.Application.Dtos.AuthorDtos;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorService(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepo.GetAllAsync();
            return authors.Select(a => new AuthorDto()
            {
                Id = a.Id,
                Name = a.Name
            });
        }
        
        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            return author is null ? null : new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public async Task<AuthorDto> AddAsync(AuthorDto authorDto)
        {
            var author = new Author()
            {
                Name = authorDto.Name
            };
            await _authorRepo.AddAsync(author);

            return new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public async Task UpdateAsync(AuthorDto authorDto)
        {
            var author = await _authorRepo.GetByIdAsync(authorDto.Id);
            if (author is null) return;

            author.Name = authorDto.Name;

            await _authorRepo.UpdateAsync(author);
        }

        public async Task DeleteAsync(int id) =>
            await _authorRepo.DeleteAsync(id);
    }
}