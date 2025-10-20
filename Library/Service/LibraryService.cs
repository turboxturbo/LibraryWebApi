using Library.DataBaseContext;
using Library.Interfaces;
using Library.Models;
using Library.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ContextDb _contextDb;
        public LibraryService(ContextDb context)
        {
            _contextDb = context;
        }
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await _contextDb.Books.ToListAsync();
            return new ObjectResult(new
            {
                data = new { books = books },
                status = true
            });
        }
        public async Task<IActionResult> GetBookId(long IdBook)
        {
            
            var books = await _contextDb.Books.FirstOrDefaultAsync(b => b.IdBook == IdBook);

            if (books == null)
            {
                return new NotFoundObjectResult(new
                {
          
                    message = $"Книга с id: {IdBook} не найдена",
                    status = false
                });
            }

            return new ObjectResult(new
            { 
                data = new { books = books },
                status = true
            });
        }
        public async Task<IActionResult> CreateBookAsync(CreateBook newBook)
        {
            var newbook = new Book
            {
                NameBook = newBook.NameBook, 
                Author = newBook.Author,
                Year = newBook.Year,
                Description = newBook.Description,
                IdGenre = newBook.IdGenre,
            };
            await _contextDb.AddAsync(newbook);
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new
            {
                StatusCode = true
            });
        }
        
    }
}
