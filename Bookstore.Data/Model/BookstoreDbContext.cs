using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Bookstore.Data.Model
{
    public class BookstoreDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public BookstoreDbContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Chapter> Chapters { get; set; }

        public static readonly ILoggerFactory DbCommandConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseLoggerFactory(DbCommandConsoleLoggerFactory)
                .UseSqlite("Data Source=bookstore.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new {ba.BookId, ba.AuthorId});
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
