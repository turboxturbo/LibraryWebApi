using Library.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Library.Interfaces
{
    public interface ILibraryService
    {
        Task<IActionResult> GetBooksAsync();
        Task<IActionResult> CreateBookAsync(CreateBook createBook);
    }
}
