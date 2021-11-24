using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTurneador.Model
{
    public class AdminContext: DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
    }
}
