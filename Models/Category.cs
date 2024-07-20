using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.Models
{
    public class Category : Entity
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        [Display(Name = "Category Name")]
        public string Name { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; }
    }
}
