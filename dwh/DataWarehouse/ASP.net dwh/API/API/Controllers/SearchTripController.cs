using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataWarehouse.Models;

namespace API.Controllers
{
	public class SearchTripController : ApiController
	{
		// GET api/<controller>?<searchTrip>
		[Queryable]
		public IEnumerable<Trip> Get([FromUri]SearchTrip searchTrip)
		{
			using (var db = new DatabaseContext())
			{
				var res =  (from t in db.Trips
					where (t.IdCityFrom == searchTrip.IdCityFrom) &&
					      (t.IdCityTo == searchTrip.IdCityTo) &&
					      
					      t.IsActive
					orderby t.StartTime
					select t).ToList();
				if (searchTrip.TripDate.Year != 1)
					res = res.Where(r => r.StartTime.Date == searchTrip.TripDate).ToList();
				//foreach (Trip t in res)
				//{
				//	//var r = t;
				//	//var cFrom = db.Cities.First(c => c.Id == r.IdCityFrom);
				//	//var cTo = db.Cities.First(c => r.IdCityTo == c.Id);
				//	//t.CityFrom = new City() { CityName = cFrom.CityName, Id = cFrom.Id };
				//	//t.CityTo = new City() { CityName = cTo.CityName, Id = cTo.Id };
				//	t.CityFrom = db.Cities.First(c => c.Id == t.IdCityFrom);
				//	t.CityTo = db.Cities.First(c => c.Id == t.IdCityTo);
				//}
				return res;
			}
		}

		// GET api/<controller>/5
		public Trip Get(int id)
		{
			using (var db = new DatabaseContext())
			{
				return db.Trips.First(c => c.Id == id);
			}
		}

		
	}
}