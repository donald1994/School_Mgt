using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School_Mgt.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Mgt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<CosProgram> CosProgram { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
