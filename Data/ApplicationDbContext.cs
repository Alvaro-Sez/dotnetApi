using BackTarjetitas.Models;
using Microsoft.EntityFrameworkCore;

namespace BackTarjetitas.Data;
 
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }
    }
