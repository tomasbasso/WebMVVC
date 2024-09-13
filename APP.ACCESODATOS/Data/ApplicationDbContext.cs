using APP.MODELO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //CARGA DE MODELOS
        public DbSet<Categoria> Categoria {get;set;}
        public DbSet<Articulo> Articulo { get; set; }
    }
}
