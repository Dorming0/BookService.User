using BookService.Core.Authors.Abstractions;
using BookService.Data;
using BookService.User.Models.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceExtender.Http;

namespace BookService.User.Controllers
{
  
    [Authorize(Roles = "user")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        protected SrvUser SrvUser => new AdminSrvUSer(HttpContext.User);

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        [HttpGet]

        public async Task<IActionResult> Filtred()
        {
            var author = await _authorService.FiltredAsync(0, int.MaxValue, null,
                (author, user) => null, SrvUser);
            if (author == null || author?.Items == null)
            {
                return NotFound();
            }

            var result = new AuthorFiltredResultUserViewModel(author.TotalCount, author.PageCount,
                author.Items.Select(x => new AuthorUserViewModel(x)));
            return View(result);
        }


        public async Task<IActionResult> Find(int authorId)
        {
            var author = await _authorService.FindAsync(x => x.Id == authorId, SrvUser);
            var result = new AuthorDetailsUserViewModel(author);
            return View(result);
        }


    }
}
