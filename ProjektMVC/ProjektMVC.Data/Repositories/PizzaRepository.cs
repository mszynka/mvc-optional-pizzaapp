using System.Collections.Generic;
using System.Linq;
using ProjektMVC.Data.Contexts;
using ProjektMVC.Data.Models;

namespace ProjektMVC.Data.Repositories
{
	public sealed class PizzaRepository
	{
		public List<Pizza> GetAll()
		{
			using (var db = new PizzaContext())
			{
				return db.Pizzas.ToList();
			}
		}
	}
}