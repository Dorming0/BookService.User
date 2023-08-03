using BookService.Core.Books;
using BookService.User.Models.Genres;

namespace BookService.User.Models.Books
{
    public class BookDetailsUserViewModel : BookUserViewModel
    {
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } = Enumerable.Empty<GenreViewModel>();

        public BookDetailsUserViewModel() { }
        public BookDetailsUserViewModel(Book book) : base(book)
        {
            Description = book.Descriptions;
            AuthorId = book.Author.Id;
            AuthorName = book.Author.Name;
            Genres = book.Genres.Select(x => new GenreViewModel(x));
        }
    }
}