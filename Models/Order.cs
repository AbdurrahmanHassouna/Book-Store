using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Display(Name ="Order Date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
       
        public  ICollection<OrderItem>? OrderItems { get; set; } 
        public string UserId { get; set; }
        public  ApplicationUser? User { get; set; }
    }
}
