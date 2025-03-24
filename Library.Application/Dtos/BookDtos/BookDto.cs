using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.Application.Dtos.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}
