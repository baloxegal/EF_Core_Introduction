using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Introduction
{
    class BookRepository : GenericRepository<Book>
    {
        public BookRepository() : base()
        {
            //_context = new LibraryContext();
            //_table = _context.Set<Book>();
        }
        public BookRepository(DbContextOptions options) : base(options)
        {
            //_context = new DbContext((DbContextOptions<LibraryContext>)options);
            //_table = _context.Set<Book>();
        }
        public BookRepository(DbContext context) :base(context)
        {
            //_context = context;
            //_table = context.Set<Book>();
        }
    }
}
