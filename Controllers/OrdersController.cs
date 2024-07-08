using AprilBookStore.DataAccess;
using AprilBookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AprilBookStore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IData data;
        private readonly UserManager<ApplicationUser> userManager;
        public OrdersController(IData data, UserManager<ApplicationUser> userManager)
        {
            this.data = data;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await data.GetOrders(User);
            return View(orders);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var order = await  data.GetOrderDetails(Id);
            return View(order);
        }
        public async Task<IActionResult> ConfirmOrder()
        {
            var user = await userManager.GetUserAsync(User);
            var order = await data.SubmitOrder(user.Id);
            if (order == null)
            {
                return RedirectToAction("Index", "Cart");
            }
            return View(order);
        }
    }
}
