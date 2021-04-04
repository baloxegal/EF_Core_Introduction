using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EF_Core_Introduction
{
    class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public LibraryContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //Scaffold-DbContext "Server=(localdb)\ProjectsV13;Database=ACDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer


        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json").Build()
        //        .GetConnectionString("DefaultConnection");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //           .Entity<Author>()
        //           .HasOne(a => a.Book)
        //           .WithOne(b => b.Author)
        //           .HasForeignKey<Book>(b => b.Autho);


        //    //modelBuilder.Entity<Author>().ToTable("AuthBooks");
        //    //modelBuilder.Entity<Book>().ToTable("AuthBooks");
        //}
    }
}
