using AprilBookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace AprilBookStore.ViewModels.User
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public List<string> Claims { get; set; }
    }
}
