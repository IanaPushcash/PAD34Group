using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Annotations;
using DataWarehouse.Models;

namespace DataWarehouse.Controllers
{
	class MyTripsController:Controller
	{
		[MethodType("GET")]
		public ActionResult GetMyTrips(SearchUserTrips userTrips)
		{
			var result = new SearchTripResult();
			using (var db = new DatabaseContext())
			{
				result.Trips = (from t in db.Trips
						where t.IdUser == userTrips.IdUser && t.IsActive
						orderby t.StartTime
						select t).Skip(userTrips.PageNumber * userTrips.RecPerPage)
					.Take(userTrips.RecPerPage)
					.ToList();
				result.CountTrips = result.Trips.Count;
			}
			return new ObjectResult(result);
		}

		[MethodType("GET")]
		public ActionResult GetMyFutureTrips(SearchUserTrips userTrips)
		{
			var result = new SearchTripResult();
			using (var db = new DatabaseContext())
			{
				result.Trips = (from t in db.Trips
						where t.IdUser == userTrips.IdUser && t.IsActive && t.StartTime > DateTime.Now
						orderby t.StartTime
						select t).Skip(userTrips.PageNumber * userTrips.RecPerPage)
					.Take(userTrips.RecPerPage)
					.ToList();
				result.CountTrips = result.Trips.Count;
			}
			return new ObjectResult(result);
		}

		[MethodType("DELETE")]
		public ActionResult DeleteTrip(long idTrip)
		{
			try
			{
				using (var db = new DatabaseContext())
				{
					var trip = db.Trips.First(t => t.Id == idTrip);
					trip.IsActive = false;
					db.SaveChanges();
				}
				return new SuccessResult(true);
			}
			catch
			{
				return new SuccessResult(true);
			}
		}

		[MethodType("POST")]
		public ActionResult AddTrip(Trip trip)
		{
			try
			{
				trip.IsActive = true;
				trip.Created = DateTime.Now;
				using (var db = new DatabaseContext())
				{
					db.Trips.Add(trip);
					db.SaveChanges();
				}
				return new ObjectResult(trip);
			}
			catch (Exception e)
			{
				return new SuccessResult(false);
			}
		}

		[MethodType("PUT")]
		public ActionResult UpdateTrip(Trip trip)
		{
			try
			{
				using (var db = new DatabaseContext())
				{
					var target = db.Trips.First(t => t.Id == trip.Id);
					target.StartTime = trip.StartTime;
					target.IdCityFrom = trip.IdCityFrom;
					target.IdCityTo = trip.IdCityTo;
					target.FromPlace = trip.FromPlace;
					target.MinutesToDest = trip.MinutesToDest;
					target.Price = trip.Price;
					db.SaveChanges();
				}
				return new SuccessResult(true);
			}
			catch (Exception e)
			{
				return new SuccessResult(false);
			}
		}
	}
}

