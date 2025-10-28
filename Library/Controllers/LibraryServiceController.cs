using System.Threading.Channels;
using Library.CustomAtributes;
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

        [HttpPut]
        [Route("api/books/{id}")]
        public async Task<IActionResult> ChangeBook(CreateBook changebook, long id)
        {
            return await _libraryService.ChangeBook(changebook, id);
        }

        [HttpDelete]
        [Route("api/books/{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            return await _libraryService.DeleteBook(id);
        }

        [HttpGet]
        [Route("api/books/genre/{nameGenre}")]
        public async Task<IActionResult> GetBookIdGenre(string nameGenre)
        {
            return await _libraryService.GetBookIdGenre(nameGenre);
        }

        [HttpGet]
        [Route("api/books/search")]
        public async Task<IActionResult> GetBookNameNAuthor(string NameBook, string Author)
        {
            return await _libraryService.GetBookNameNAuthor(NameBook, Author);
        }

        [HttpGet]
        [Route("api/readers")]
        public async Task<IActionResult> GetReaders()
        {
            return await _libraryService.GetReaders();
        }
        [HttpGet]
        [Route("api/readers{id}")]
        public async Task<IActionResult> GetReaderId(long id)
        {
            return await _libraryService.GetReaderId(id);
        }
        [HttpPost]
        [Route("api/readers")]
        public async Task<IActionResult> CreateReader(CreateReader newreader)
        {
            return await _libraryService.CreateReader(newreader);
        }
        [HttpPut]
        [Route("api/readers")]
        public async Task<IActionResult> ChangeReader(CreateReader changereader, long IdReader)
        {
            return await _libraryService.ChangeReader(changereader, IdReader);
        }
        [HttpDelete]
        [Route("api/readers")]
        public async Task<IActionResult> DeleteReader(long IdReader)
        {
            return await _libraryService.DeleteReader(IdReader);
        }
        [HttpGet]
        [Route("api/genres")]
        public async Task<IActionResult> GetGenres()
        {
            return await _libraryService.GetGenresAsync();
        }
        [HttpPost]
        [Route("api/genres")]
        public async Task<IActionResult> CreateNewgenre(CreateGenres newgenre)
        {
            return await _libraryService.CreateNewgenre(newgenre);
        }
        [HttpPut]
        [Route("api/genres")]
        public async Task<IActionResult> ChangeGenre(CreateGenres genre, long IdGenre)
        {
            return await _libraryService.ChangeGenre(genre, IdGenre);
        }
        [HttpDelete]
        [Route("api/genres")]
        public async Task<IActionResult> DeleteGenre(long IdGenre)
        {
            return await _libraryService.DeleteGenre(IdGenre);
        }
        [HttpPost]
        [Route("api/rents")]
        public async Task<IActionResult> CreateRent(CreateRent createRent)
        {
            return await _libraryService.CreateRent(createRent);
        }
        [HttpPut]
        [Route("api/rentals/return")]
        public async Task<IActionResult> ChangeRent(ReturnBook returnbook, long IdRent)
        {
            return await _libraryService.ChangeRent(returnbook, IdRent);
        }
        [HttpGet]
        [Route("api/rentals/history/reader")]
        public async Task<IActionResult> GetHistoryName(string Name)
        {
            return await _libraryService.GetHistoryName(Name);
        }
        [HttpGet]
        [Route("api/rentals/history/book")]
        public async Task<IActionResult> GetHistoryNameBook(string NameBook)
        {
            return await _libraryService.GetHistoryNameBook(NameBook);
        }
        [HttpGet]
        [Route("api/rentals/current")]
        public async Task<IActionResult> GetCurrentHistory()
        {
            return await _libraryService.GetCurrentHistory();
        }

        [HttpPost]
        [Route("authuser")]
        public async Task<IActionResult> AuthUser([FromBody] AuthUser newUser)
        {
            return await _libraryService.AuthUser(newUser);
        }
        [HttpPost]
        [Route("createNewLogin")]
        [RoleAuthAtribute([1, 2])]
        public async Task<IActionResult> CreateNewUserAndLoginAsync([FromBody]CreateUser user)
        {
            return await _libraryService.CreateNewUserAndLoginAsync(user);
        }
        [HttpGet]
        [Route("getallusers")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            return await _libraryService.GetAllUserAsync();
        }
    }
}

