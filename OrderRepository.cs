using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Introduction
{
    class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository()
        {
                
        }
        public OrderRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<Order>();
        }
    }
}
