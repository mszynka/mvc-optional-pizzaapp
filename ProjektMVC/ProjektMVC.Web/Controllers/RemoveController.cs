using System.Linq;
using System.Web.Mvc;
using ProjektMVC.Data.Repositories;
using ProjektMVC.Web.Models;

namespace ProjektMVC.Web.Controllers
{
	public sealed class RemoveController : Controller
	{
		private readonly PizzaRepository _pizzaRepository;
		private readonly IngredientRepository _ingredientRepository;

		public RemoveController()
		{
			_pizzaRepository = new PizzaRepository();
			_ingredientRepository = new IngredientRepository();
		}

		[HttpGet]
		public ActionResult Ingredient(int ingredientId)
		{
			var ingredient = _ingredientRepository.Get(ingredientId);
			if(!ingredient.Any())
			{
				ViewBag.Error = "Cannot find ingredient";
				return View(new RemoveIngredientModel());
			}

			var pizzas = _pizzaRepository.GetAllByIngredient(ingredientId);
			var ingr = ingredient.Single();
			var model = new RemoveIngredientModel
			{
				IngredientId = ingr.IngredientId,
				IngredientName = ingr.Name,
				PizzasWithIngredient = pizzas
			};

			return View(model);
		}

		[HttpPost]
		public ActionResult RemoveIngredient(int ingredientId)
		{
			if (_pizzaRepository.GetAllByIngredient(ingredientId).Any())
				ViewBag.Error = "Cannot remove ingredient. Still used in some pizzas";
			else
				_ingredientRepository.Remove(ingredientId);

			return RedirectToAction("Ingredients", "List");
		}
	}
}