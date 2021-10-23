using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentSchduleMVC.Helper
{
    public static class Helper
    {
        public static readonly string Admin = "Admin";
        public static readonly string Patient = "Patient";
        public static readonly string Doctor = "Doctor";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Value = Helper.Admin, Text = Helper.Admin},
                new SelectListItem {Value = Helper.Patient, Text = Helper.Patient},
                new SelectListItem {Value = Helper.Doctor, Text = Helper.Doctor}
            };
        }
        
    }
}