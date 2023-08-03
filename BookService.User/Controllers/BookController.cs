using BookService.Core.Books;
using BookService.Core.Books.Abstractions;
using BookService.Data;
using BookService.User.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceExtender.Http;

namespace BookService.User.Controllers
{

    [Authorize(Roles = "user")]

    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        protected SrvUser SrvUser => new AdminSrvUSer(HttpContext.User);

        public BookController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }
        [HttpGet]

        public async Task<IActionResult> Filtred()
        {
            var books = await _bookService.FiltredAsync(0, int.MaxValue, x => x.Status == BookStatus.Active, SrvUser);
            if (books == null || books?.Items == null)
            {
                return NotFound();
            }

            var result = new BookFiltredUserViewModel(books.TotalCount, books.PageCount, books.Items.Select(x => new BookUserViewModel(x)));


            return View(result);
        }

        public async Task<IActionResult> Find(int bookId)
        {
            var book = await _bookService.FindAsync(x => x.Id == bookId, SrvUser);

            var result = new BookDetailsUserViewModel(book);

            return View(result);
        }



    }
}
