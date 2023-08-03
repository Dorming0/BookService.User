using BookService.Core.Genres;

namespace BookService.User.Models.Genres
{
    public class GenresDetailsViewModel : GenreViewModel
    {
        public string? Description { get; set; }
        public GenresDetailsViewModel() { }
        public GenresDetailsViewModel(Genre genres) : base(genres)
        {
            Description = genres.Description;
        }
    }
}
