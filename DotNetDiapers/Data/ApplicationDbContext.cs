using System;
using System.Collections.Generic;
using System.Text;
using DotNetDiapers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetDiapers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // reference the data model classes
        public DbSet<Guest> Guests { get; set; }
        public DbSet<BabyPrediction> BabyPredictions { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // override the OnModelCreating method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
