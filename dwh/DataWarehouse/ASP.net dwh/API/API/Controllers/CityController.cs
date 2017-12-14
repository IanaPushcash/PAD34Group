using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataWarehouse.Models;

namespace API.Controllers
{
	public class CityController : ApiController
	{
		// GET api/<controller>
		[Queryable]
		public IEnumerable<City> Get()
		{
			using (var db = new DatabaseContext())
			{
				return db.Cities.ToList();
			}
		}

		// GET api/<controller>/5
		public City Get(int id)
		{
			using (var db = new DatabaseContext())
			{
				return db.Cities.First(c=>c.Id == id);
			}
		}

		// POST api/<controller>
		public void Post([FromBody]City value)
		{
			using (var db = new DatabaseContext())
			{
				db.Cities.Add(value);
				db.SaveChanges();
			}
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]City value)
		{
			using (var db = new DatabaseContext())
			{
				var updCity = db.Cities.FirstOrDefault(c => c.Id == id);
				if (updCity != null)
				{
					updCity.CityName = value.CityName;
					db.SaveChanges();
				}
			}
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			using (var db = new DatabaseContext())
			{
				var rmvCity = db.Cities.FirstOrDefault(c => c.Id == id);
				if (rmvCity != null)
				{
					db.Cities.Remove(rmvCity);
					db.SaveChanges();
				}
			}
		}
	}
}