using Library.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Library.Interfaces
{
    public interface ILibraryService
    {
        Task<IActionResult> GetBooksAsync();
        Task<IActionResult> CreateBookAsync(CreateBook createBook);
        Task<IActionResult> GetBookId(long id);
        Task<IActionResult> ChangeBook(CreateBook changebook, long IdBook);
        Task<IActionResult> DeleteBook(long IdBook);
        Task<IActionResult> GetBookIdGenre(string NameGenre);
        Task<IActionResult> GetBookNameNAuthor(string NameBook, string Author);
        Task<IActionResult> GetReaders();
        Task<IActionResult> GetReaderId(long IdReader);
        Task<IActionResult> CreateReader(CreateReader newreader);
        Task<IActionResult> ChangeReader(CreateReader changereader, long IdReader);
        Task<IActionResult> DeleteReader(long IdReader);
        Task<IActionResult> GetGenresAsync();
        Task<IActionResult> CreateNewgenre(CreateGenres newgenre);
        Task<IActionResult> ChangeGenre(CreateGenres genre, long IdGenre);
        Task<IActionResult> DeleteGenre(long IdGenre);
        Task<IActionResult> CreateRent(CreateRent createRent);
        Task<IActionResult> ChangeRent(ReturnBook returnbook, long IdRent);
        Task<IActionResult> GetHistoryName(string Name);
        Task<IActionResult> GetHistoryNameBook(string NameBook);
        Task<IActionResult> GetCurrentHistory();
        Task<IActionResult> AuthUser(AuthUser newUser);
        Task<IActionResult> CreateNewUserAndLoginAsync(CreateUser user);
        Task<IActionResult> GetAllUserAsync();
    }
}
