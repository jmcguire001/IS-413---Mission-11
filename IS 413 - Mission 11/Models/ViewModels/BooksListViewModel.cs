using Mission11_McGuire.Models.ViewModels;

namespace Mission11_McGuire.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IQueryable<Book> Books { get; set; } // This is a collection of <Project> instances
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo(); // WHY DO WE NOT NEED TO <> THIS? We don't need <> because PaginationInfo is just a class, not a collection
    }
}

