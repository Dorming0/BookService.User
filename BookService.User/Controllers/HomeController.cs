using BookService.Core.Carts;
using BookService.Data;
using BookService.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServiceExtender.Http;
using System.Diagnostics;

namespace BookService.User.Controllers
{
   
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string _cartPrefix = "cart_";
        private readonly IMemoryCache _memoryCache;
        protected SrvUser SrvUser => new AdminSrvUSer(HttpContext.User);

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public IActionResult Index()
        {
            var cart = _memoryCache.Get<Cart>(_cartPrefix + SrvUser.Id);
            if (cart==null)
            {
                cart = new Cart();
                _memoryCache.Set(_cartPrefix + SrvUser.Id, cart);
            }
            return View(cart);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
