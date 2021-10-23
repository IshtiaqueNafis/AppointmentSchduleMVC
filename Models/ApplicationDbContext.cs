using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchduleMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        // means idenity db contenxt get additional property from Application Db context. hfbd                                                      3                           `   
                         
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}