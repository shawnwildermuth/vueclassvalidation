using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueClassValidation.Data.Entities;

namespace VueClassValidation.Data
{
  public class CustomerContext : DbContext
  {
    public CustomerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder bldr)
    {
      base.OnModelCreating(bldr);

      BindModel(bldr.Entity<Customer>());
    }

    private void BindModel(EntityTypeBuilder<Customer> bldr)
    {
      bldr.ToTable("Customers", "Sales");
      bldr.Property(c => c.FirstName)
        .HasMaxLength(50);
      bldr.Property(c => c.LastName)
        .HasMaxLength(50);
      bldr.Property(c => c.AddressLine1)
        .HasMaxLength(100);
      bldr.Property(c => c.AddressLine2)
        .HasMaxLength(100);
      bldr.Property(c => c.AddressLine3)
        .HasMaxLength(100);
      bldr.Property(c => c.CityTown)
        .HasMaxLength(50);
      bldr.Property(c => c.StateProvince)
        .HasMaxLength(50);
      bldr.Property(c => c.PostalCode)
        .HasMaxLength(20);
      bldr.Property(c => c.Country)
        .HasMaxLength(50);
      bldr.Property(c => c.PhoneNumber)
        .HasMaxLength(50);

      bldr.HasData(
        new Customer[]
        {
          new Customer()
          {
            Id = 1,
            FirstName = "Shawn",
            LastName = "Wildermuth",
            PhoneNumber = "404-555-1212",
            AddressLine1 = "123 Main Street",
            CityTown = "Atlanta",
            StateProvince = "GA",
            PostalCode = "12345",
            UserName = "shawn@wildermuth.com"
          }
        });
    }
  }
}
