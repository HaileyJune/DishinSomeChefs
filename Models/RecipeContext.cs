using Microsoft.EntityFrameworkCore;

namespace DishinSomeChefs.Models
{
    public class RecipeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options) { }
        public DbSet<Chef> Chef {get;set;}
        public DbSet<Dish> Dish {get;set;}

    }
}