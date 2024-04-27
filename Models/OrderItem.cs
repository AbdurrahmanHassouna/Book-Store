using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    public class OrderItem
    {
        [Key]

        public int Id { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [Display(Name ="Book Name")]
        public string BookName { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }
}
