using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataBaseContext
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<HistoryRentBook> HistoryRentBooks { get; set; } = null!;

    }
}
