using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RazorAPP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Adding Models as DB sets to create table
        public DbSet<MainAdmin> MainAdmins { get; set; }
        public DbSet<MainStaff> MainStaffs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
