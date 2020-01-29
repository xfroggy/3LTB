using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3LTB.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _3LTB.Data
{
    public class _3LTBContext : IdentityDbContext<ApplicationUser>
    {
        public _3LTBContext(DbContextOptions<_3LTBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
