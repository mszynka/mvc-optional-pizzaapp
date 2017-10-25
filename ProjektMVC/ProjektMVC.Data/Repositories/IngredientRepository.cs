using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using ProjektMVC.Data.Contexts;
using ProjektMVC.Data.Models;

namespace ProjektMVC.Data.Repositories
{
	public sealed class IngredientRepository
	{
		public List<Ingredient> GetAll()
		{
			using (var db = new PizzaContext())
			{
				return db.Ingredients.ToList();
			}
		}

		public Option<Ingredient> Get(int id)
		{
			using (var db = new PizzaContext())
			{
				return db.Ingredients
					.AsNoTracking()
					.FirstOrDefault(x => x.IngredientId == id)
					.AsOption<Ingredient>();
			}
		}

		public void Add(string name)
		{
			using(var db = new PizzaContext())
			{
				db.Ingredients.Add(new Ingredient
				{
					Name = name
				});
				db.SaveChanges();
			}
		}

		public void Remove(int ingredientId)
		{
			using(var db = new PizzaContext())
			{
				var ingredient = db.Ingredients.Find(ingredientId);
				db.Ingredients.Remove(ingredient ?? throw new InvalidOperationException());
				db.SaveChanges();
			}
		}
	}
}