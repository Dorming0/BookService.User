namespace BookService.User.Models.Authors
{
    public class AuthorFiltredResultUserViewModel
    {
        public int TotalCount { get; set; }
        public int ItemsPageCount { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<AuthorUserViewModel> Items { get; set; } = Enumerable.Empty<AuthorUserViewModel>();

        public AuthorFiltredResultUserViewModel() { }
        public AuthorFiltredResultUserViewModel(int totalCount, int itemsPageCount, IEnumerable<AuthorUserViewModel> items)
        {
            TotalCount = totalCount;
            ItemsPageCount = itemsPageCount;
            PageCount = (int)Math.Ceiling((double)TotalCount / ItemsPageCount);
            Items = items;
        }
    }
}

