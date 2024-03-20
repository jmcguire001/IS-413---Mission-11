using Mission11_McGuire.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Mission11_McGuire.Models.ViewModels;

namespace Mission11_McGuire.Controllers
{
    public class HomeController : Controller
    {
        // Set up a repository
        private IBookstoreRepository _repo;

        // Connect the repository to the controller
        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum) // 'page' means something in dotnet, so we use 'pageNum' instead
        {
            int pageSize = 10; // How many items to show per page

            // This variable will hold everything from BooksListViewModel, and then be passed to Index.cshtml
            var bookData = new BooksListViewModel
            {
                // This info is for the projects specifically
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize) // Will skip a certain number of records so that it doesn't keep showing the same thing
                    .Take(pageSize), // Only gets a certain number of books

                // This info is for pagination
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(bookData);
        }
    }
}
