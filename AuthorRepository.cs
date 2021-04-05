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
        public AuthorRepository() : base()
        {
            
        }
        public AuthorRepository(DbContextOptions options) : base(options)
        {
            
        }
        public AuthorRepository(DbContext context) :base(context)
        {

        }
    }
}
