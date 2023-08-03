using BookService.Core.Books.Abstractions;
using BookService.Core.Carts;
using BookService.Data;
using BookService.User.Models.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServiceExtender.Http;

namespace BookService.User.Controllers
{

    [Authorize(Roles = "user")]
    public class CartController : Controller

    {
        private const string _cartPrefix = "cart_";
        private readonly IMemoryCache _memoryCache;
        private readonly IBookService _bookService;
        protected SrvUser SrvUser => new AdminSrvUSer(HttpContext.User);

        public CartController(IMemoryCache memoryCache, IBookService bookService)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        public IActionResult GetCart()
        {

            var cart = _memoryCache.Get<Cart>(_cartPrefix + SrvUser.Id);


            if (cart == null)
            {
                cart = new Cart();
                _memoryCache.Set(_cartPrefix + SrvUser.Id, cart);
            }

            var model = new CartViewModel(cart);
            return View(model);
        }

        public async Task<IActionResult> AddItem(int bookId)
        {
            var cart = _memoryCache.Get<Cart>(_cartPrefix + SrvUser.Id);
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            var book = await _bookService.FindAsync(x => x.Id == bookId, SrvUser);
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            var model = new CartItem(book.Id, book.Name, book.Price);

            cart.AddCartItem(model);

            var result = new CartViewModel(cart);

            _memoryCache.Set(_cartPrefix + SrvUser.Id, cart);

            return RedirectToAction("Filtred","Book");
        }

        public IActionResult RemoveItem(int itemId)
        {
            var cart = _memoryCache.Get<Cart>(_cartPrefix + SrvUser.Id);
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            var item = cart.CartItems.FirstOrDefault(x => x.Id == itemId);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            cart.RemuveItem(item);
            var result = new CartViewModel(cart);
            _memoryCache.Set(_cartPrefix + SrvUser.Id, cart);

            return RedirectToAction("GetCart");
        }
    }
}
