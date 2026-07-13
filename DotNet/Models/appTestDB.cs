using appTest.Models;
using Microsoft.EntityFrameworkCore;

namespace appTest.Models
{
    public class appTestDB : DbContext

    {
        public appTestDB(DbContextOptions<appTestDB> options)
            : base(options)
        {

        }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Fournisseurs> fournisseurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
    }
}
