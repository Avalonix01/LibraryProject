using Library.Domain.Enums;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public BookStatus Status { get; set; } = BookStatus.Available;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
