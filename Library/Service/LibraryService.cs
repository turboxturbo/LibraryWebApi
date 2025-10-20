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
            if (books == null || books.Count == 0)
            {
                return new NotFoundObjectResult(new
                {
                    message = "Книги не найдены",
                    status = false
                });
            }
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
            try
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
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    message = ex.Message,
                    status = false
                });
            }
        }
        public async Task<IActionResult> ChangeBook(CreateBook changebook, long IdBook)
        {
            //var book = await _contextDb.Books.FindAsync(IdBook);
            var book = await _contextDb.Books.FirstOrDefaultAsync(b => b.IdBook == IdBook);
            if (book == null)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"Книга с id: {IdBook} не найдена",
                    status = false
                });
            }
            book.NameBook = changebook.NameBook;
            book.Author = changebook.Author;
            book.Description = changebook.Description;
            book.Year = changebook.Year;
            book.IdGenre = changebook.IdGenre;

            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new
            {
                StatusCode = true
            });
        }
        public async Task<IActionResult> DeleteBook(long IdBook)
        {
            var book = await _contextDb.Books.FirstOrDefaultAsync(u => u.IdBook == IdBook);
            if (book == null)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"Книга с id: {IdBook} не найдена",
                    status = false
                });
            }
            _contextDb.Remove(book);
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new
            {
                StatusCode = true
            });
        }
        public async Task<IActionResult> GetBookIdGenre(string NameGenre)
        {
            var book = await _contextDb.Books.Where(u => u.Genre.Name == NameGenre).ToListAsync();
            if (book == null || book.Count == 0)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"Книга с жанром: {NameGenre} не найдена",
                    status = false
                });
            }

            return new OkObjectResult(new
            {
                data = new { book = book },
                status = true,
            });
        }
        public async Task<IActionResult> GetBookNameNAuthor(string NameBook, string Author)
        {
            var book = _contextDb.Books.FirstOrDefault(u => u.NameBook == NameBook && u.Author == Author);
            if (book == null)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"Книга с названием: {NameBook} и автором: {Author} не найдена",
                    status = false
                });
            }
            return new OkObjectResult(new
            {
                data = new { book = book },
                status = true,
            });
        }
        public async Task<IActionResult> GetReaders()
        {
            var readers = await _contextDb.Readers.ToListAsync();
            if (readers == null || readers.Count == 0)
            {
                return new NotFoundObjectResult(new { message = "Читатели не найдены", status = false });
            }
            return new ObjectResult(new { data = new { reader = readers }, status = true });
        }
        public async Task<IActionResult> GetReaderId(long IdReader)
        {
            var reader = await _contextDb.Readers.FirstOrDefaultAsync(r => r.IdReader == IdReader);
            if (reader == null)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"Читатель с id: {IdReader} не найден",
                    status = false
                });
            }
            return new OkObjectResult(new
            {
                data = new { reader = reader },
                status = true
            });
        }
        public async Task<IActionResult> CreateReader(CreateReader newreader)
        {
            try
            {
                var reader = new Reader
                {
                    Name = newreader.Name,
                    Age = newreader.Age,
                    PhoneNumber = newreader.PhoneNumber,
                };
                await _contextDb.AddAsync(reader);
                await _contextDb.SaveChangesAsync();
                return new OkObjectResult(new { status = true });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Ошибка {ex}", status = false });
            }
        }
        public async Task<IActionResult> ChangeReader(CreateReader changereader, long IdReader)
        {
            var reader = await _contextDb.Readers.FirstOrDefaultAsync(r => r.IdReader == IdReader);
            if (reader == null)
            {
                return new NotFoundObjectResult(new { message = $"Читатель с id: {IdReader} не найден", status = false });
            }
            reader.Name = changereader.Name;
            reader.Age = changereader.Age;
            reader.PhoneNumber = changereader.PhoneNumber;
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new { status = true });
        }
        public async Task<IActionResult> DeleteReader(long IdReader)
        {
            var reader = await _contextDb.Readers.FirstOrDefaultAsync(r => r.IdReader == IdReader);
            if (reader == null)
            {
                new NotFoundObjectResult(new { message = $"Читатетль с id: {IdReader} не найден" });
            }
            _contextDb.Remove(reader);
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new { status = true });
        }
        public async Task<IActionResult> GetGenresAsync()
        {
            var genres = await _contextDb.Genres.ToListAsync();
            if (genres == null || genres.Count == 0)
            {
                return new NotFoundObjectResult(new
                {
                    message = "Жанры не найдены",
                    status = false
                });
            }
            return new OkObjectResult(new { genres = genres, status = true });
        }
        public async Task<IActionResult> CreateNewgenre(CreateGenres newgenre)
        {
            var genre = new Genre { Name = newgenre.Name };
            await _contextDb.AddAsync(genre);
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new { data = new { genres = genre }, status = true });
        }
        public async Task<IActionResult> ChangeGenre(CreateGenres genre, long IdGenre)
        {
            var changegenre = await _contextDb.Genres.FirstOrDefaultAsync(r => r.IdGenre == IdGenre);
            if (genre == null)
            {
                return new NotFoundObjectResult(new { message = $"Жанр с id: {IdGenre} не найден", status = false });
            }
            changegenre.Name = genre.Name;
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new { status = true });

        }
        public async Task<IActionResult> DeleteGenre(long IdGenre)
        {
            var genre = await _contextDb.Genres.FirstOrDefaultAsync(r => r.IdGenre == IdGenre);
            if (genre == null)
            {
                return new NotFoundObjectResult(new { message = $"Жанр с id: {IdGenre} не найден", status = false });
            }
            _contextDb.Remove(genre);
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new { status = true });
        }
        public async Task<IActionResult> CreateRent(CreateRent createRent)
        {
            try
            {
                var rent = new HistoryRentBook
                {
                    IdReader = createRent.IdReader,
                    IdBook = createRent.IdBook,
                    DateStart = createRent.DateStart,
                    DateEnd = createRent.DateEnd,
                };
                await _contextDb.AddAsync(rent);
                await _contextDb.SaveChangesAsync();
                return new OkObjectResult(new { status = true });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    message = ex.Message,
                    status = false
                });
            }
        }
        public async Task<IActionResult> ChangeRent(CreateRent changeRent, long IdRent) // возврат книги
        {
            var rent = await _contextDb.HistoryRentBooks.FirstOrDefaultAsync(r => r.IdRent == IdRent);
            if (rent == null)
            {
                return new NotFoundObjectResult(new { message = $"Аренда с id: {IdRent} не найдена", status = false });
            }
            rent.IdReader = changeRent.IdReader;
            rent.IdBook = changeRent.IdBook;
            rent.DateStart = changeRent.DateStart;
            rent.DateEnd = changeRent.DateEnd;
            await _contextDb.SaveChangesAsync();
            return new OkObjectResult(new { status = true });
        }
        public async Task<IActionResult> GetHistoryName(string Name)
        {
            var history = await _contextDb.HistoryRentBooks.Where(u => u.reader.Name == Name).ToListAsync();
            if (history == null || history.Count == 0)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"История аренды для читателя с именем: {Name} не найдена",
                    status = false
                });
            }
            return new OkObjectResult(new
            {
                data = new { history = history },
                status = true,
            });
        }
        public async Task<IActionResult> GetHistoryNameBook(string NameBook)
        {
            var history = await _contextDb.HistoryRentBooks.Where(u => u.book.NameBook == NameBook).ToListAsync();
            if (history == null || history.Count == 0)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"История аренды для читателя с именем: {NameBook} не найдена",
                    status = false
                });
            }
            return new OkObjectResult(new
            {
                data = new { history = history },
                status = true,
            });
        }
        public async Task<IActionResult> GetCurrentHistory()
        {
            var histtory = await _contextDb.HistoryRentBooks.Include(h => h.book).Include(h => h.reader).Where(h => h.DateEnd > DateTime.Now).ToListAsync();
            if (histtory == null || histtory.Count == 0)
            {
                return new NotFoundObjectResult(new
                {
                    message = $"Текущих аренд не найдено",
                    status = false
                });
            }
            return new OkObjectResult(new
            {
                data = new { histtory = histtory },
                status = true,
            });
        }
    }
}
