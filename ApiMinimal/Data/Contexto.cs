using ApiMinimal.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinimal.Data
{
    public class Contexto :DbContext
    {
        public Contexto(DbContextOptions<Contexto>options):base(options) 
            => Database.EnsureCreated();
        public DbSet<Cliente> clientes { get; set; }

    }
}
