using System.ComponentModel.DataAnnotations;

namespace AprilBookStore.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required , Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
