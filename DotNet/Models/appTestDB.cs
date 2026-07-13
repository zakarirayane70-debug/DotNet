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
        public DbSet<Medicament> Medicament{ get; set; }
        public DbSet<Fournisseurs> Fournisseurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
    }
}
