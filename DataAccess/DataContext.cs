﻿using AprilBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.InteropServices;
namespace AprilBookStore.DataAccess
{
    public class DataContext : IData
    {
        private BookStoreContext bookStoreContext;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        public DataContext(BookStoreContext bookStoreContext
            , UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.bookStoreContext = bookStoreContext;
            this.userManager = userManager;
            this.signInManager = signInManager;


        }
        public ICollection<Book> GetBooks(Author author)
        {
           
            return GetBooks().Where(b=>b.Author == author).ToList();
        }
        public ICollection<Book> GetBooks()
        {

            return bookStoreContext.Books.Include(a => a.Author).Include(a => a.Category).ToList();
        }
        public ICollection<Book> GetBooks(Category category)
        {
            return GetBooks().Where(b => b.Category == category).ToList();
        }
        public Book? GetBook(int id) {
            
            return GetBooks().Where(c=>c.Id==id).FirstOrDefault();
        }
        public ICollection<Book> SearchBook(string search)
        {
            var books = bookStoreContext.Books.Include(a => a.Author).Include(a => a.Category)
                .Where(b => b.Name.StartsWith(search)).ToList();
            books.AddRange(bookStoreContext.Books.Include(a => a.Author).Include(a => a.Category)
                .Where(b => b.Name.Contains(search) && !b.Name.StartsWith(search)));
            return books;
        }
        public async Task<int> GetCartItemsCountAsync(ClaimsPrincipal claims)
        {
            var user = await userManager.GetUserAsync(claims);
            return (await GetCartItemsAsync()).Where(c=>c.User==user).Count();

        }
        public async Task<ICollection<CartItem>> GetCartItemsAsync()
        {
            
            var cartItems = bookStoreContext.CartItems
                .Include(C => C.User).Include(C => C.Book).ToList();

            return cartItems;
        }
        public async Task<int> AddToCart(Book book)
        {
            var user = await userManager.GetUserAsync(signInManager.Context.User);

            var cartItems = bookStoreContext.CartItems.Where(c => c.BookId==book.Id&&c.UserId==user.Id);
            
            if (cartItems.Count()!=0)
            {
                var cartItem = cartItems.Where(b => b.BookId==book.Id).First();
                if (cartItem != null && cartItem.Quantity<book.QuantityInStock) { 
                cartItem.Quantity= cartItem.Quantity+1;
                cartItem.Price+=book.Price;
                await UpdateCartItem(cartItem);
                }
                return await GetCartItemsCountAsync(signInManager.Context.User);
            }
            var newCartItem = new CartItem
            {
                BookId = book.Id,
                Quantity =1,
                UserId = (await userManager.GetUserAsync(signInManager.Context.User)).Id,
                Price = book.Price

            };

            await bookStoreContext.AddAsync(newCartItem);
            await bookStoreContext.SaveChangesAsync();
            return await GetCartItemsCountAsync(signInManager.Context.User);

        }
        public async Task<int> DeleteCartItem(CartItem cartItem)
        {
            bookStoreContext.Remove(cartItem);

            return await bookStoreContext.SaveChangesAsync();
        }
        public async Task<int> UpdateCartItem(CartItem cartItem)
        {
           
            bookStoreContext.Update(cartItem);
            return await bookStoreContext.SaveChangesAsync();
        }
        public async Task<ICollection<Order>> GetOrders()
        {
            var user = await userManager.FindByEmailAsync(signInManager.Context.User.FindFirstValue(ClaimTypes.Email));
            var Orders = bookStoreContext.Orders.Where(o => o.UserId==user.Id).ToList();
            return Orders;
        }
        public async Task<Order> GetOrderDetails(int orderId)
        {

            ICollection<OrderItem> orderItems = bookStoreContext.OrderItems.Where(o => o.OrderId==orderId).ToList();
            Order order = (await bookStoreContext.Orders.FindAsync(orderId));
            order.OrderItems = orderItems;

            return order;
        }
        public async Task<Order>? SubmitOrder(string UserId)
        {
            ICollection<CartItem> cartItems= bookStoreContext.CartItems.Where(c=>c.UserId==UserId).Include(c=>c.Book).ToList();
            if (cartItems.Count == 0)
            {
                return null;
            }
            Order order=new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = cartItems.Sum(c=>c.Book.Price*c.Quantity),
                UserId = UserId,
                OrderItems= new List<OrderItem>()
            };
            foreach(var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    BookName = cartItem.Book.Name,
                    Price = cartItem.Book.Price,
                    Quantity = cartItem.Quantity
                };
                cartItem.Book.QuantityInStock-=cartItem.Quantity;
                if (cartItem.Book.QuantityInStock <0) throw new Exception("Error Quantity");
                bookStoreContext.Update(cartItem.Book);
                order.OrderItems.Add(orderItem);
            }
            bookStoreContext.RemoveRange(cartItems);
            await bookStoreContext.AddAsync(order);
            await bookStoreContext.SaveChangesAsync();
            return order;
        }
        public ICollection<Author> GetAuthors()
        {
            return bookStoreContext.Authors.ToList();
        }
        public Author GetAuthor(int id)
        {
            return bookStoreContext.Authors.Where(a=>a.Id==id).FirstOrDefault();
        }
        public ICollection<Category> GetCategories()
        {
            return bookStoreContext.Categories.ToList();
        }
        public Category GetCategory(int id)
        {
            return bookStoreContext.Categories.Where(a => a.Id==id).FirstOrDefault();
        }
        public void AddBook(Book book) {
            bookStoreContext.Books.Add(book);
            bookStoreContext.SaveChangesAsync().Wait();
        }
    }
}
