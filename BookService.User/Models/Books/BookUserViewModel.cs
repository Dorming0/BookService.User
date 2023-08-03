using BookService.Core.Books;

namespace BookService.User.Models.Books
{
    public class BookUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }


        public BookUserViewModel() { }
        public BookUserViewModel(Book book)
        {
            if (book != null)
            {
                Id = book.Id;
                Name = book.Name;
                Price = book.Price;
                AuthorName = book.Author.Name;
            }
        }
    }
}
