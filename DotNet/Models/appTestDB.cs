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
        public DbSet<Produit> Produits { get; set; }
    }
}
