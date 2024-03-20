namespace Mission11_McGuire.Models
{
    // Create the repository interface
    public interface IBookstoreRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
