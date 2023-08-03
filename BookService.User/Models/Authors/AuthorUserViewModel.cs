using BookService.Core.Authors;

namespace BookService.User.Models.Authors
{
    public class AuthorUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public AuthorUserViewModel() { }
        public AuthorUserViewModel(Author author)
        {
            if (author != null)
            {
                Id = author.Id;
                Name = author.Name;
                Surname = author.Surname;
            }
        }
    }
}
