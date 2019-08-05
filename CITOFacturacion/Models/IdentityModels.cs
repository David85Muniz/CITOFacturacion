using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using CITOFacturacion.Models.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.IO;
using System;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CITOFacturacion.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<SubDivision> SubDivisions { get; set; }

        public DbSet<SubDivision2ndLv> SubDivision2ndLv { get; set; }

        public DbSet<Neighborhood> Neighborhoods { get; set; }

        public DbSet<BillingAddress> BillingAddresses { get; set; }

        public DbSet<Zone> Zones { get; set; }

        public System.Data.Entity.DbSet<CITOFacturacion.Models.Entities.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<CITOFacturacion.Models.Entities.FreightRequest> FreightRequests { get; set; }
    }
}