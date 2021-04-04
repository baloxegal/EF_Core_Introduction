using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_Core_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build()
                .GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlServer(connectionString)
                .Options;


            //With custom repository


            var repAuthor = new AuthorRepository(new LibraryContext(options));
            var repCustomer = new CustomerRepository(new LibraryContext(options));
            var repBook = new BookRepository(new LibraryContext(options));
            var repOrder = new OrderRepository(new LibraryContext(options));

            repAuthor.Insert(new Author("Ghita", 44));
            repAuthor.Insert(new Author("Petrica", 30));
            repAuthor.Insert(new Author("Vasile", 62));
            repAuthor.Insert(new Author("Valerica", 44));
            repAuthor.Insert(new Author("Ioane", 81));
            repAuthor.Insert(new Author("Tolica", 37));

            var c = repAuthor.FindAll();

            foreach (var v in c)
            {
                Console.WriteLine(v);
            }

            var d = repAuthor.FindById(4);

            Console.WriteLine(d);

            var e = repAuthor.FindByPredicate(a => a.Age == 44);

            foreach (var v in e)
            {
                Console.WriteLine(v);
            }

            var f = repAuthor.FindById(3);
            f.Name = "Alexei";
            repAuthor.Update(f);

            Console.WriteLine(f);

            repAuthor.Delete(5);

            var h = repAuthor.FindAll();

            foreach (var v in h)
            {
                Console.WriteLine(v);
            }

            var i = repAuthor.FindById(2);
            repAuthor.Delete(i);

            var j = repAuthor.FindAll();

            foreach (var v in j)
            {
                Console.WriteLine(v);
            }


            //With generic repository


            //var repAuthor = new GenericRepository<Author>( new LibraryContext(options));
            //var repCustomer = new GenericRepository<Customer>(new LibraryContext(options));
            //var repBook = new GenericRepository<Book>(new LibraryContext(options));
            //var repOrder = new GenericRepository<Order>(new LibraryContext(options));

            //repAuthor.Insert(new Author("Ghita", 45));
            //repAuthor.Insert(new Author("Petrica", 30));
            //repAuthor.Insert(new Author("Vasile", 62));
            //repAuthor.Insert(new Author("Valerica", 44));
            //repAuthor.Insert(new Author("Ioane", 81));
            //repAuthor.Insert(new Author("Tolica", 37));

            //var c =  repAuthor.FindAll();

            //foreach (var v in c)
            //{
            //    Console.WriteLine(v);
            //}



            //Without repository



            ////CREATE (INSERT)
            //using (var lc = new LibraryContext(options))
            //{
            //    lc.Add(new Author("Ghita", 45));
            //    lc.Add(new Author("Petrica", 30));
            //    lc.Add(new Author("Vasile", 62));
            //    lc.Add(new Author("Valerica", 44));
            //    lc.Add(new Author("Ioane", 81));
            //    lc.Add(new Author("Tolica", 37));

            //    lc.Authors.Add(new Author("Aurica", 31));

            //    lc.SaveChanges();
            //}

            ////READ (SELECT ALL)
            //using (var lc = new LibraryContext(options))
            //{
            //    var list = lc.Authors.ToList();
            //    foreach (var a in list)
            //    {
            //        Console.WriteLine(a);
            //    }
            //}

            ////READ BY ID (SELECT BY ID)
            //using (var lc = new LibraryContext(options))
            //{
            //    var a = lc.Find<Author>(1);
            //    Console.WriteLine(a);
            //}

            ////UPDATE
            //using (var lc = new LibraryContext(options))
            //{
            //    var a = lc.Find<Author>(7);

            //    a.Name = "Igor";

            //    lc.Update(a);
            //    lc.SaveChanges();

            //    var b = lc.Find<Author>(7);
            //    Console.WriteLine(b);
            //}

            ////DELETE
            //using (var lc = new LibraryContext(options))
            //{
            //    var a = lc.Find<Author>(6);

            //    lc.Remove(a);
            //    lc.SaveChanges();

            //    var b = lc.Find<Author>(6);
            //    var list = lc.Authors.ToList();
            //    foreach (var l in list)
            //    {
            //        Console.WriteLine(l);
            //    }
            //}
        }
    }
}
