using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataWarehouse.Models;

namespace API.Controllers
{
	public class TripAllController : ApiController
	{
		// GET api/<controller>
		[Queryable]
		public IEnumerable<Trip> Get()
		{
			using (var db = new DatabaseContext())
			{
				return db.Trips.ToList();
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

		// POST api/<controller>
		public Trip Post([FromBody]Trip value)
		{
			value.IsActive = true;
			value.Created = DateTime.Now;
			using (var db = new DatabaseContext())
			{
				db.Trips.Add(value);
				db.SaveChanges();
			}
			value.IdCityTo = value.IdCityTo;
			value.IdCityFrom = value.IdCityFrom;
			return value;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]Trip value)
		{
			using (var db = new DatabaseContext())
			{
				var updTrip = db.Trips.FirstOrDefault(c => c.Id == id);
				if (updTrip != null)
				{
					if (value.CityFrom != null) updTrip.CityFrom = value.CityFrom;
					if (value.CityTo != null) updTrip.CityTo = value.CityTo;
					if (value.IdUser != null) updTrip.IdUser = value.IdUser;
					if (value.Price != null) updTrip.Price = value.Price;
					if (value.FromPlace != null) updTrip.FromPlace = value.FromPlace;
					if (value.StartTime != null) updTrip.StartTime = value.StartTime;
					if (value.MinutesToDest != null) updTrip.MinutesToDest = value.MinutesToDest;
					if (value.IsActive != null) updTrip.IsActive = value.IsActive;
					db.SaveChanges();
				}
			}
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			using (var db = new DatabaseContext())
			{
				var rmvTrip = db.Trips.FirstOrDefault(c => c.Id == id);
				if (rmvTrip != null)
				{
					var trip = db.Trips.First(t => t.Id == id);
					trip.IsActive = false;
					db.SaveChanges();
				}
			}
		}
	}
}