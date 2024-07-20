using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AprilBookStore.Models;

namespace AprilBookStore.ViewModels.Book
{
    public class EditBookViewModel:Entity
    {
        [Display(Name = "Rating"), Range(0, 5, ErrorMessage = "max rating is 5 stars")]
        public double BookStar { get; set; }
        [Display(Name = "Book Name")]
        public string Name { get; set; }
        
        public string Format { get; set; }
        
        public long ISBN { get; set; }
        
        public decimal Price { get; set; }
        [DisplayName("Categroy")]
        public int CategoryId { get; set; }
        [Required, DisplayName("Author")]
        public int AuthorId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublicationYear { get; set; }
        [Display(Name = "Quantity")]
        public int QuantityInStock { get; set; }
        [Display(Name = "Book Cover")]
        public IFormFile? BookCoverFile { get; set; }
        public string Description { get; set; }
        
    }
}
