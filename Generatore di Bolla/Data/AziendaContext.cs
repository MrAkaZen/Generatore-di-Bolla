using Generatore_di_Bolla.Personale;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generatore_di_Bolla.Data
{
    public class AziendaContext : DbContext
    {
        public DbSet<Bolla> Bolle { get; set; } = null!;
        public DbSet<Responsabile>  Responsabili { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
