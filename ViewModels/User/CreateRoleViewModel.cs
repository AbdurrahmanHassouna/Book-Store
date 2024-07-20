using System.ComponentModel.DataAnnotations;

namespace AprilBookStore.ViewModels.User
{
    public class CreateRoleViewModel
    {
        [Required, Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
