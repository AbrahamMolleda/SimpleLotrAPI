using LOTRAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LotrAPI.Data
{
    public class LotrContext : DbContext
    {
        public LotrContext(DbContextOptions<LotrContext> options) : base(options)
        {
            
        }

        public DbSet<Personaje> personajes { get; set; }
    }
}