using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }
    }
}
