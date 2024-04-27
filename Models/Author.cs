using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public bool IsVisible { get; set; } = true;
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime UpdatedDate { get; set; }
        public  ICollection<Book> Books { get; set; }
    }
}
