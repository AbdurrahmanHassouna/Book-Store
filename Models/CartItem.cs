using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ApplicationUser? User { get; set; }
        public Book? Book { get; set; }

    }
}
