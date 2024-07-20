using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Book : Entity
    {
        [Display(Name = "Book Name")]
        public string Name { get; set; } = null!;
        public string Format { get; set; } = null!;
        public long ISBN { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Display(Name="Image")]
        public string? ImgPath { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        [DisplayFormat(NullDisplayText ="no rating")]
        public double? BookStar { get; set; }
        [Column(TypeName = "date")]
        public DateTime PublicationYear { get; set; }
        public string? Description { get; set; }
        public int QuantityInStock { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Category? Category { get; set; }
    }
}
