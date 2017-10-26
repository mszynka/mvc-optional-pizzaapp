using System.Collections.Generic;
using System.Linq;
using Common;
using ProjektMVC.Data.Contexts;
using ProjektMVC.Data.Models;
using ProjektMVC.Data.ValueObjects;

namespace ProjektMVC.Data.Repositories
{
	public sealed class PizzaRepository
	{
		public List<Pizza> GetAll()
		{
			using (var db = new PizzaContext())
			{
				return db.Pizzas
					.Include(nameof(Pizza.Ingredients))
					.ToList();
			}
		}

		public Option<Pizza> Get(int id)
		{
			using(var db = new PizzaContext())
			{
				return db.Pizzas
					.Include(nameof(Pizza.Ingredients))
					.Include("Ingredients.Ingredient")
					.AsNoTracking()
					.FirstOrDefault(x => x.PizzaId == id)
					.AsOption<Pizza>();
			}
		}

		public void Add(string name, PizzaSize size, PizzaPieThickness thickness, List<PizzaIngredient> ingredients)
		{
			using (var db = new PizzaContext())
			{
				var entity = new Pizza
				{
					Name = name,
					Size = size,
					Thickness = thickness,
					Ingredients = ingredients
				};
				db.Pizzas.Add(entity);
				foreach(var ingredient in ingredients)
				{
					ingredient.Pizza = entity;
				}
				db.SaveChanges();
			}
		}

		public List<Pizza> GetAllByIngredient(int ingredientId)
		{
			using(var db = new PizzaContext())
			{
				return db.Pizzas
					.Include(nameof(Pizza.Ingredients))
					.AsNoTracking()
					.Where(p => p.Ingredients.Any(i => i.IngredientId == ingredientId))
					.ToList();
			}
		}
	}
}