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
					where (searchTrip.IdCityFrom == null || t.IdCityFrom == searchTrip.IdCityFrom) &&
					      (searchTrip.IdCityTo == null || t.IdCityTo == searchTrip.IdCityTo) &&
					      //  (searchTrip.TripDate != null
					      //? t.StartTime > searchTrip.TripDate.Date.AddDays(-1) && t.StartTime < searchTrip.TripDate.Date.AddDays(1)
					      //: t.StartTime > DateTime.Now) &&
					      t.IsActive
					orderby t.StartTime
					select t).ToList();
				for (int i = 0; i < res.Count; i++)
				{
					
					var cFrom = db.Cities.First(c => c.Id == res[i].IdCityFrom);
					var cTo = db.Cities.First(c => c.Id == res[i].IdCityTo);
					res[i].CityFrom = cFrom;
					res[i].CityTo = cTo;
				}
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