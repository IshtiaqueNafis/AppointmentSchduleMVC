using Microsoft.AspNetCore.Identity;

namespace AppointmentSchduleMVC.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        
    }
}