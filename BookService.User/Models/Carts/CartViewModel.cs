using BookService.Core.Carts;

namespace BookService.User.Models.Carts
{
    public class CartViewModel
    {
        public string Id { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<CartItemViewModel> Items { get; set; } = Enumerable.Empty<CartItemViewModel>();
        public CartViewModel() { }
        public CartViewModel(Cart cart)
        {
            Id = cart.Id;
            TotalCount = cart.TotalCount;
            TotalPrice = cart.TotalPrice;
            Items = cart.CartItems.Select(x => new CartItemViewModel(x));
        }

    }
}
