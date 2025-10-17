using Library.Interfaces;
using Library.Models;
using Library.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryServiceController 
    {
        public readonly ILibraryService _libraryService;
        public LibraryServiceController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        [HttpGet]
        [Route("api/books")]
        public async Task<IActionResult> GetBooks()
        {
            return await _libraryService.GetBooksAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookwithId(GetBookwithid book)
        {
            var book = await _context.Book.
        }
        [HttpPost]
        [Route("api/books")]
        public async Task<IActionResult> CreateBook(CreateBook createBook) 
        {
            return await _libraryService.CreateBookAsync(createBook);
        }
        
    }
}

