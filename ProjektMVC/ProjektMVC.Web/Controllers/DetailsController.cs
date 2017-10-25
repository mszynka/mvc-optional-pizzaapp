using System;
using System.Linq;
using System.Web.Mvc;
using ProjektMVC.Data.Repositories;

namespace ProjektMVC.Web.Controllers
{
	public sealed class DetailsController : Controller
	{
		private readonly PizzaRepository _pizzaRepository;

		public DetailsController()
		{
			_pizzaRepository = new PizzaRepository();
		}

		[HttpGet]
		public ViewResult Pizza(int id)
		{
			var pizza = _pizzaRepository.Get(id);
			if(!pizza.Any())
				throw new ArgumentException("Wrong pizza Id");

			return View(pizza.Single());
		}
	}
}