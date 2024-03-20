using Mission11_McGuire.Models.ViewModels;

namespace Mission11_McGuire.Models.ViewModels
{
    // This class collects all the Book data and the PaginationInfo
    public class BooksListViewModel
    {
        public IQueryable<Book> Books { get; set; } // This is a collection of <Project> instances
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo(); // Creates a single instance of PaginationInfo
    }
}