using Library.Application.Dtos.BookDtos;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                AuthorId = b.AuthorId
            });
        }
        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book is null ? null : new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId
            };
        }

        public async Task AddAsync(BookDto bookDto)
        {
            var book = new Book()
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId
            };
            await _bookRepo.AddAsync(book);
        }
        public async Task UpdateAsync(BookDto bookDto)
        {
            var book = await _bookRepo.GetByIdAsync(bookDto.Id);
            if (book is null) return;

            book.Title = bookDto.Title;
            book.AuthorId = bookDto.AuthorId;

            await _bookRepo.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id) =>
            await _bookRepo.DeleteAsync(id);
    }
}