using System.Collections.Generic;
using ProjektMVC.Data.ValueObjects;

namespace ProjektMVC.Data.Models
{
	public class Pizza
	{
		public int PizzaId { get; set; }

		public string Name { get; set; }

		public PizzaSize Size { get; set; }

		public PizzaPieThickness Thickness { get; set; }

		public virtual List<PizzaIngredient> Ingredients { get; set; }
	}
}