using AprilBookStore.Controllers;
using AprilBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace AprilBookStore.DataAccess
{
    public interface IData
    {
        ICollection<Book> GetBooks(Author author);
        ICollection<Book> GetBooks();
        Book? GetBook(int  id);
        ICollection<Book> GetBooks(Category category);
        ICollection<Author> GetAuthors();
        Author GetAuthor(int id);
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Book> SearchBook(string search);
        Task<int> GetCartItemsCountAsync(ClaimsPrincipal claims);
        Task<ICollection<CartItem>> GetCartItemsAsync();
        Task<int> AddToCart(Book book);
        Task<int> DeleteCartItem(CartItem cartItem);
        Task<int> UpdateCartItem(CartItem cartItem);
        Task<ICollection<Order>> GetOrders();
        Task<Order> GetOrderDetails(int orderId);
        Task<Order> SubmitOrder(string userId);
        void AddBook(Book book);

    }
}
