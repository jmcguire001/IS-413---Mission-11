using Microsoft.EntityFrameworkCore;

namespace Mission11_McGuire.Models
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {
        }

        // Create a DbSet for the Book model
        public DbSet<Book> Books { get; set; }
    }
}
