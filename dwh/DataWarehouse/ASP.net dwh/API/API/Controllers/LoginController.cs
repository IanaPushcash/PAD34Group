using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataWarehouse.Models;

namespace API.Controllers
{
	public class LoginController : ApiController
	{
		// POST api/<controller>
		public User Post([FromBody]User value)
		{
			using (var db = new DatabaseContext())
			{
				var users = db.Users.Where(u => u.Login == value.Login).ToList();
				users = users.Where(u => u.Password ==
				                         UserController.CalculateMD5Hash(value.Password + u.Created.ToString("yy-MM-dd")))
					.ToList();
				if (users.Count == 1)
					return users.First();
			}
			return new User();
		}
	}
}