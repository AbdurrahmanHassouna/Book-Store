using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Remote("Name","Books",ErrorMessage ="There is a book with the same Name")]
        public string Name { get; set; } = null!;
        public string Format { get; set; } = null!;
        public long ISBN { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string? ImgPath { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        [DisplayFormat(NullDisplayText ="no rating")]
        public double? BookStar { get; set; }
        [Column(TypeName = "date")]
        public DateTime PublicationYear { get; set; }
        public string? Description { get; set; }
        public int QuantityInStock { get; set; }
        public bool? IsDeleted { get; set; }= false;
        public bool? IsVisible { get; set; } = true;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy:MM:dd}")]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy:MM:dd}")]
        public DateTime UpdatedDate { get; set; }
        public virtual Author Author { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
