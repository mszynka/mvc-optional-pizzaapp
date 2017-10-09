using System.Collections.Generic;
using ProjektMVC.Db.ValueObjects;

namespace ProjektMVC.Db.Models
{
	public class Pizza
	{
		public int PizzaId { get; set; }

		public string Name { get; set; }

		public PizzaPrice Price { get; set; }

		public PizzaPieThickness Thickness { get; set; }

		public virtual List<PizzaIngredient> Ingredients { get; set; }
	}
}