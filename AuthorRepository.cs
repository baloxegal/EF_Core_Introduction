using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Introduction
{
    class AuthorRepository : GenericRepository<Author>
    {
        public AuthorRepository()
        {
            _context = new LibraryContext();
            _table = _context.Set<Author>();
        }
        public AuthorRepository(DbContextOptions options)
        {
            _context = new DbContext((DbContextOptions<LibraryContext>)options);
            _table = _context.Set<Author>();
        }
        public AuthorRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<Author>();
        }
    }
}
