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
            
        }
        public CustomerRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<Customer>();
        }
    }
}
