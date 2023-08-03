using BookService.Core.Carts;

namespace BookService.User.Models.Carts
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set;}
        public decimal TotalPrice=> Price*Count;
        public int Count { get; set; }

        public CartItemViewModel() { }
        public CartItemViewModel(CartItem item)
        {
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            Count = item.Count;
        }
    }
}
