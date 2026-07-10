using appTest.Models;
using Microsoft.EntityFrameworkCore;

namespace appTest.Models
{
    public class FournisseursDB : DbContext
    {
        public FournisseursDB(DbContextOptions<FournisseursDB> options)
           : base(options)
        {
        }
        public DbSet<Fournisseurs> fournisseurs{ get; set; }
    }
}
