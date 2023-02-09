using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDExample.Models;

namespace CRUDExample.Data
{
    public class CRUDExampleContext : DbContext
    {
        public CRUDExampleContext (DbContextOptions<CRUDExampleContext> options)
            : base(options)
        {
        }

        public DbSet<CRUDExample.Models.Phone> Phone { get; set; } = default!;
    }
}
