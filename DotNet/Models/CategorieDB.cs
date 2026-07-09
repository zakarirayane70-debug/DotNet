using appTest.Models;
using Microsoft.EntityFrameworkCore;

namespace appTest.Models
{
    public class CategorieDB : DbContext
    {
        public CategorieDB(DbContextOptions<CategorieDB> options)
           : base(options)
        {
        }
        public DbSet<Categorie> Categories { get; set; }
    }
}
