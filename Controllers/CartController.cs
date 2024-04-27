using AprilBookStore.DataAccess;
using AprilBookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AprilBookStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IData data;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(IData data, UserManager<ApplicationUser> _userManager)
        {
            this.data = data;
            userManager=_userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var cart = (await data.GetCartItemsAsync()).Where(b => b.User==user).ToList();
            return View(cart);
        }
        [HttpPost]
        public async Task<int> AddtoCart(int bookId)
        {
            var book = data.GetBooks().Where(data => data.Id == bookId).First();
            return (await data.AddToCart(book));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCart(int bookId, int Quantity)
        {
            var user = await userManager.GetUserAsync(User);
            CartItem cartItem = (await data.GetCartItemsAsync()).Where(b => b.BookId==bookId&&b.User==user).First();
            if (Quantity == 0)
            {
                await data.DeleteCartItem(cartItem);
            }
            else
            {
                cartItem.Quantity= Quantity;
                cartItem.Price= cartItem.Quantity*cartItem.Book.Price;
                await data.UpdateCartItem(cartItem);
            }
            var cartItems = await data.GetCartItemsAsync();
            return PartialView("_Cart", cartItems);
        }

        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var cartItem = (await data.GetCartItemsAsync()).Where(c => c.BookId==id).FirstOrDefault();
            await data.DeleteCartItem(cartItem);
            var cartItems = await data.GetCartItemsAsync();

            return PartialView("_Cart", cartItems);
        }
    }
}
