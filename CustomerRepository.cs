using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Introduction
{
    class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository()
        {
            _context = new LibraryContext();
            _table = _context.Set<Customer>();
        }
        public CustomerRepository(DbContextOptions options)
        {
            _context = new DbContext((DbContextOptions<LibraryContext>)options);
            _table = _context.Set<Customer>();
        }
        public CustomerRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<Customer>();
        }
    }
}
