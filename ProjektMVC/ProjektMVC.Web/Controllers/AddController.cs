using System.Linq;
using System.Web.Mvc;
using ProjektMVC.Data.Models;
using ProjektMVC.Data.Repositories;
using ProjektMVC.Web.Models;

namespace ProjektMVC.Web.Controllers
{
	public sealed class AddController : Controller
	{
		private readonly PizzaRepository _pizzaRepository;
		private readonly IngredientRepository _ingredientRepository;

		public AddController()
		{
			_pizzaRepository = new PizzaRepository();
			_ingredientRepository = new IngredientRepository();
		}

		[HttpGet]
		public ActionResult AddIngredient()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddIngredient(AddIngredientModel model)
		{
			_ingredientRepository.Add(model.Name);
			return RedirectToAction("Ingredients", "List");
		}

		[HttpGet]
		public ActionResult AddPizza()
		{
			var ingredients = _ingredientRepository.GetAll();
			return View(new AddPizzaModel
			{
				IngredientsDictionary = ingredients
			});
		}

		[HttpPost]
		public ActionResult AddPizza(AddPizzaModel model)
		{
			var ingredients = HttpContext.Request.Form.Get("Ingredients").Split(',').Select(int.Parse);
			foreach(var ingredient in ingredients)
			{
				model.Ingredients.Add(new PizzaIngredient
				{
					IngredientId = ingredient
				});
			}

			_pizzaRepository.Add(model.Name, model.Size, model.Thickness, model.Ingredients);
			return RedirectToAction("Menu", "List");
		}
	}
}