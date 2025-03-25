using Library.Application.Dtos.BookDtos;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Library.UI.Pages
{
    public partial class Book
    {
        private List<BookDto> books = new();
        private bool loading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadBooks();
        }

        private async Task LoadBooks()
        {
            try
            {
                loading = true;
                books = await Http.GetFromJsonAsync<List<BookDto>>("api/Books") ?? new();
            }
            catch (Exception ex)
            {
                books = new();
                Console.WriteLine($"Error loading books: {ex.Message}");
            }
            finally
            {
                loading = false;
            }
        }

        private async Task DeleteBook(int id)
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete this book?"))
            {
                try
                {
                    await Http.DeleteAsync($"api/Books/{id}");
                    await LoadBooks();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting book: {ex.Message}");
                }
            }
        }
    }
}