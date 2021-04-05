using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build()
                .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }


        //One To One Relations made with Fluent API

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //           .Entity<Author>()
        //           .HasOne(a => a.Book)
        //           .WithOne(b => b.Author)
        //           .HasForeignKey<Book>(b => b.Autho);


        //It is to make one table from two classes

        //    //modelBuilder.Entity<Author>().ToTable("AuthBooks");
        //    //modelBuilder.Entity<Book>().ToTable("AuthBooks");
        //}


        //Use Config class for Mapping Domain Class

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FIND CONFIGURATION FILES BY TYPE 
            modelBuilder.ApplyConfiguration(new BookConfig());

            //FIND ALL CONFIGURATION FILES  
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }


        //Use this for define composite key - Fluent API

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>().HasKey(x => x.Id);
        //    modelBuilder.Entity<Author>().HasKey(x => new { x.Id });
        //    //modelBuilder.Entity<AuthorBook>().HasKey(x => new { x.BookId, x.Author.Id });
        //    
        //    //Behavior on delete
        //    //.OnDelete(DeleteBehavior.Cascade);
        //}

        //Or this - Data Annotations

        //[Table("BooksAuth")]
        //class BookAuthor
        //{
        //    [Key] [Column(Order = 0)] public int BookId { get; set; }
        //    [Key] [Column("Auth", Order = 1)] public int AuthorId { get; set; }
        //    public string Title { get; set; }
        //    public string Description { get; set; }
        //}
        //}

        //It is config class for modeling domain class made with Fluent API

        class BookConfig : IEntityTypeConfiguration<Book>
        {
            public void Configure(EntityTypeBuilder<Book> builder)
            {
                builder.HasKey(x => x.Id);

                builder.HasMany(x => x.Authors)
                       .WithMany(x => x.Books)
                       .UsingEntity(x => x.ToTable("AuthorsBooks"));

                builder.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(1000);

                builder.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                builder.Property(x => x.Available)
                    .IsRequired();

                builder.Property(x => x.Cover)
                    .HasMaxLength(1000);
                
                builder.Property(x => x.Price)
                    .IsRequired();

            }
        }
    }
}
