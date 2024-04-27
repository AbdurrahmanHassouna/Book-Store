using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AprilBookStore.Models;

namespace AprilBookStore.ViewModels
{
    public class CreateBookViewModel
    {
        [Display(Name = "Rating"), Range(0, 5, ErrorMessage = "max rating is 5 stars")]
        public double BookStar { get; set; }
        [Display(Name = "Book Name"), Required]
        [Remote("Name", "Books", ErrorMessage = "There is a book with the same Name")]
        public string? Name { get; set; }
        [Required]
        public string? Format { get; set; }
        [Required]
        public long? ISBN { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required, DisplayName("Categroy")]
        public int? CategoryId { get; set; }
        [Required, DisplayName("Author")]
        public int? AuthorId { get; set; }
        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}"), DisplayName("Publication Date")]
        public System.DateTime PublicationYear { get; set; }
        [Required, Display(Name = "Quantity")]
        public int? QuantityInStock { get; set; }
        [Display(Name = "Book Cover")]
        public IFormFile? BookCoverFile { get; set; }
        public string? Description { get; set; }
        public SelectList? selectListItems { get; set; }
    }
}
