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
        [Route("api/books/{id}")]
        public async Task<IActionResult> GetBooksID(long id)
        {
            return await _libraryService.GetBookId(id);
        }


        [HttpPost]
        [Route("api/books")]
        public async Task<IActionResult> CreateBook(CreateBook createBook) 
        {
            return await _libraryService.CreateBookAsync(createBook);
        }
        
    }
}

