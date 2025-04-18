namespace Library.Application.Dtos.BookDtos
{
    public class BookUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}
