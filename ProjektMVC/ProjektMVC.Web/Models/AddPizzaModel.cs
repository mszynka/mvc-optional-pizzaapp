using System.Collections.Generic;
using ProjektMVC.Data.Models;
using ProjektMVC.Data.ValueObjects;

namespace ProjektMVC.Web.Models
{
	public sealed class AddPizzaModel
	{
		public string Name { get; set; }
		public PizzaSize Size { get; set; }
		public PizzaPieThickness Thickness { get; set; }
		public List<PizzaIngredient> Ingredients { get; set; }

		public List<Ingredient> IngredientsDictionary { get; set; }
	}
}