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
				return (from t in db.Trips
					where (searchTrip.IdCityFrom == null || t.IdCityFrom == searchTrip.IdCityFrom) &&
					      (searchTrip.IdCityTo == null || t.IdCityTo == searchTrip.IdCityTo) &&
					      //  (searchTrip.TripDate != null
					      //? t.StartTime > searchTrip.TripDate.Date.AddDays(-1) && t.StartTime < searchTrip.TripDate.Date.AddDays(1)
					      //: t.StartTime > DateTime.Now) &&
					      t.IsActive
					orderby t.StartTime
					select t).ToList();
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