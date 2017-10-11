using System.Web.Mvc;
using ProjektMVC.Data.Repositories;

namespace ProjektMVC.Web.Controllers
{
	public sealed class AddController : Controller
	{
		public PizzaRepository PizzaRepository;
		public IngredientRepository IngredientRepository;

		public AddController()
		{
			PizzaRepository = new PizzaRepository();
		}

		[HttpGet]
		public ActionResult AddIngredient()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddIngredient(string pizzaFilter)
		{
			return View();
		}

		[HttpGet]
		public ActionResult AddPizza()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[HttpPost]
		public ActionResult AddPizza(string pizzaFilter)
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
	}
}