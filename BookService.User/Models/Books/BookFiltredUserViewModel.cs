namespace BookService.User.Models.Books
{
    public class BookFiltredUserViewModel
    {
        public int TotalCount { get; set; }
        public int ItemsPageCount { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<BookUserViewModel> Items { get; set; } = Enumerable.Empty<BookUserViewModel>();

        public BookFiltredUserViewModel() { }
        public BookFiltredUserViewModel(int totalCount, int itemsPageCount, IEnumerable<BookUserViewModel> items)
        {
            TotalCount = totalCount;
            ItemsPageCount = itemsPageCount;
            PageCount = (int)Math.Ceiling((double)TotalCount / ItemsPageCount);
            Items = items;
        }
    }
}
