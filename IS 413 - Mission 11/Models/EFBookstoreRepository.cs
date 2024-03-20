using System.Runtime.CompilerServices;

namespace Mission11_McGuire.Models
{
    // Create the EFBookstoreRepository class that implements the IBookstoreRepository interface
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext _context;

        public EFBookstoreRepository(BookstoreContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
