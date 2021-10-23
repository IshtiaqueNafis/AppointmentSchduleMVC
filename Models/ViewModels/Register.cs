using System.ComponentModel.DataAnnotations;

namespace AppointmentSchduleMVC.Models.ViewModels
{
    public class Register
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = $"The password must be 6 characters long")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Both password must match")]
        public string ConfirmPassword { get; set; }
       
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}