using System.Linq;
using System.Web.Mvc;
using ProjektMVC.Data;
using ProjektMVC.Data.Repositories;

namespace ProjektMVC.Web.Controllers
{
	public class ListController : Controller
	{
		public PizzaRepository PizzaRepository;

		public ListController()
		{
			PizzaRepository = new PizzaRepository();
		}

		public ActionResult Menu(string pizzaFilter = null)
		{
			var pizzas = PizzaRepository.GetAll();

			if (!string.IsNullOrWhiteSpace(pizzaFilter))
				pizzas = pizzas
					.Where(x => x.Name.StartsWith(pizzaFilter))
					.ToList();

			return View(pizzas);
		}

		public ActionResult Ingredients()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
	}
}