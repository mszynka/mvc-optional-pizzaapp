using System.Linq;
using System.Web.Mvc;
using ProjektMVC.Data.Repositories;
using ProjektMVC.Web.Models;

namespace ProjektMVC.Web.Controllers
{
	public sealed class RenameController : Controller
	{
		private readonly IngredientRepository _ingredientRepository;

		public RenameController()
		{
			_ingredientRepository = new IngredientRepository();
		}

		[HttpGet]
		public ActionResult Ingredient(int id)
		{
			var ingredient = _ingredientRepository.Get(id);

			if (!ingredient.Any())
			{
				ViewBag.Error = "Ingredient not found!";
				return RedirectToAction("Ingredients", "List");
			}

			var model = new RenameIngredientModel
			{
				Id = id,
				Name = ingredient.Single().Name
			};

			return View(model);
		}

		[HttpPost]
		public ActionResult RenameIngredient(RenameIngredientModel model)
		{
			if (string.IsNullOrWhiteSpace(model.Name))
			{
				ViewBag.Error = "Name cannot be empty";
				return RedirectToAction("Ingredient", new { id = model.Id });
			}

			_ingredientRepository.Rename(model.Id, model.Name);

			return RedirectToAction("Ingredients", "List");
		}
	}
}