using BookService.Core.Authors;
using BookService.User.Models.Books;
using BookService.User.Models.Genres;

namespace BookService.User.Models.Authors
{
    public class AuthorDetailsUserViewModel : AuthorUserViewModel
    {
        public string? Description { get; set; }
        public string? GenreName { get; set; }
        public string? BookName { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } = Enumerable.Empty<GenreViewModel>();
        public IEnumerable<BookUserViewModel> Books { get; set; } = Enumerable.Empty<BookUserViewModel>();



        public AuthorDetailsUserViewModel() { }
        public AuthorDetailsUserViewModel(Author author) : base(author)
        {
            Description = author.Description;
            Genres = author.Genres.Select(x => new GenreViewModel(x));
            Books = author.Books.Select(x => new BookUserViewModel(x));
        }
    }
}
