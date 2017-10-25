using System;
using System.Linq;
using System.Web.Mvc;
using ProjektMVC.Data.Repositories;

namespace ProjektMVC.Web.Controllers
{
	public class ListController : Controller
	{
		private readonly PizzaRepository _pizzaRepository;
		private readonly IngredientRepository _ingredientRepository;

		public ListController()
		{
			_pizzaRepository = new PizzaRepository();
			_ingredientRepository = new IngredientRepository();
		}

		public ActionResult Menu(string pizzaFilter = null)
		{
			var pizzas = _pizzaRepository.GetAll();

			if (!string.IsNullOrWhiteSpace(pizzaFilter))
				pizzas = pizzas
					.Where(x => x.Name.StartsWith(pizzaFilter, StringComparison.CurrentCultureIgnoreCase))
					.ToList();

			ViewBag.pizzaFilter = pizzaFilter;

			return View(pizzas);
		}

		public ActionResult Ingredients()
		{
			var ingredients = _ingredientRepository.GetAll();

			return View(ingredients);
		}
	}
}