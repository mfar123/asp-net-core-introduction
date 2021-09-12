using Microsoft.EntityFrameworkCore;

namespace FilmesCrud.Models
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {

        }
        public DbSet<Filmess> Filmes {get;set;}
    }
}