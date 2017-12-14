using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataWarehouse.Models;

namespace API.Controllers
{
	public class SearchUserTripsController : ApiController
	{
		// GET api/<controller>/<iduser>
		[Queryable]
		public IEnumerable<Trip> Get(int idUser)
		{
			using (var db = new DatabaseContext())
			{
				return db.Trips.Where(t=> t.IdUser == idUser).ToList();
			}
		}

		


	}
}