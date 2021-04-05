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
        public CustomerRepository() :base()
        {
            
        }
        public CustomerRepository(DbContextOptions options) : base(options)
        {
            
        }
        public CustomerRepository(DbContext context) : base(context)
        {
            
        }
    }
}
