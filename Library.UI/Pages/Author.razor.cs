using Library.Application.Dtos.AuthorDtos;
using System.Net.Http.Json;

namespace Library.UI.Pages
{
    public partial class Author
    {
        private List<AuthorDto> authors = new();
        private bool loading = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadAuthors();
        }

        private async Task LoadAuthors()
        {
            try
            {
                loading = true;
                authors = await Http.GetFromJsonAsync<List<AuthorDto>>("api/Authors") ?? new();
            }
            catch (Exception ex)
            {
                authors = new();
                Console.WriteLine($"Error loading authors: {ex.Message}");
            }
            finally
            {
                loading = false;
            }
        }
    }
}