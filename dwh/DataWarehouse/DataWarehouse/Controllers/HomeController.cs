using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Annotations;
using DataWarehouse.Models;

namespace DataWarehouse.Controllers
{
	class HomeController:Controller
	{
		[MethodType("GET")]
		public ActionResult CityList()
		{
			var cities = new List<City>();
			using (var db = new DatabaseContext())
			{
				cities = db.Cities.ToList();
			}
			return new ObjectResult(cities);
		}

		








		
	}
}
