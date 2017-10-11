using System.Data.Entity;
using ProjektMVC.Data.Models;

namespace ProjektMVC.Data.Contexts
{
	public sealed class PizzaContext : DbContext
	{
		public DbSet<Pizza> Pizzas { get; set; }
		
		public DbSet<Ingredient> Ingredients { get; set; }
	}
}