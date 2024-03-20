namespace Mission11_McGuire.Models.ViewModels
{
    // This class is used to store information about the pagination of the books
    public class PaginationInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumPages => (int) (Math.Ceiling((decimal) TotalItems / ItemsPerPage)); // Divide int by int doesn't work in C#?
    }
}