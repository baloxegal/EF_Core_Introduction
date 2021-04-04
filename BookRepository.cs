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
        public BookRepository()
        {
            _context = new LibraryContext();
            _table = _context.Set<Book>();
        }
        public BookRepository(DbContextOptions options)
        {
            _context = new DbContext((DbContextOptions<LibraryContext>)options);
            _table = _context.Set<Book>();
        }
        public BookRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<Book>();
        }
    }
}
