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

		[MethodType("GET")]
		public ActionResult SearchTrip(SearchTrip searchTrip)
		{
			var result = new SearchTripResult();
			using (var db = new DatabaseContext())
			{
				result.Trips = (from t in db.Trips
						where (searchTrip.IdCityFrom == null || t.IdCityFrom == searchTrip.IdCityFrom) &&
						      (searchTrip.IdCityTo == null || t.IdCityTo == searchTrip.IdCityTo) &&
						    //  (searchTrip.TripDate != null
								  //? t.StartTime > searchTrip.TripDate.Date.AddDays(-1) && t.StartTime < searchTrip.TripDate.Date.AddDays(1)
								  //: t.StartTime > DateTime.Now) &&
							  t.IsActive
						orderby t.StartTime
						select t).Skip(searchTrip.PageNumber * searchTrip.RecPerPage)
					.Take(searchTrip.RecPerPage)
					.ToList();
				result.CountTrips = result.Trips.Count;
			}
			return new ObjectResult(result);
		}

	}
}
