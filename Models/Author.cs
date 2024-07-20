using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    public class Author : Entity
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        [Display(Name = "Author Name")]
        public string Name { get; set; } = null!;
        public ICollection<Book> Books { get; set; }
    }
}
