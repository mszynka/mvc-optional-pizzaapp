using System.Collections.Generic;
using ProjektMVC.Data.Models;

namespace ProjektMVC.Web.Models
{
	public sealed class RemoveIngredientModel
	{
		public int IngredientId { get; set; }

		public string IngredientName { get; set; }

		public List<Pizza> PizzasWithIngredient { get; set; } = new List<Pizza>(0);
	}
}