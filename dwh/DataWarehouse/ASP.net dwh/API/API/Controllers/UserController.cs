using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DataWarehouse.Models;

namespace API.Controllers
{
	public class UserController : ApiController
	{
		// GET api/<controller>
		[Queryable]
		public IEnumerable<User> Get()
		{
			using (var db = new DatabaseContext())
			{
				return db.Users.ToList();
			}
		}

		// GET api/<controller>/5
		public User Get(int id)
		{
			using (var db = new DatabaseContext())
			{
				return db.Users.First(c => c.Id == id);
			}
		}

		// POST api/<controller>
		public User Post([FromBody]User value)
		{
			using (var db = new DatabaseContext())
			{
				value.Created = DateTime.Now;
				value.Password = CalculateMD5Hash(value.Password + value.Created.ToString("yy-MM-dd"));
				db.Users.Add(value);
				db.SaveChanges();
			}
			return value;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]User value)
		{
			using (var db = new DatabaseContext())
			{
				var updUser = db.Users.FirstOrDefault(c => c.Id == id);
				if (updUser != null)
				{
					if (value.Email != null) updUser.Email = value.Email;
					if (value.Login != null) updUser.Login = value.Login;
					if (value.Password != null) updUser.Password = 
							CalculateMD5Hash(value.Password + updUser.Created.ToString("yy-MM-dd"));
					db.SaveChanges();
				}
			}
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			using (var db = new DatabaseContext())
			{
				var rmvUser = db.Users.FirstOrDefault(c => c.Id == id);
				if (rmvUser != null)
				{
					db.Users.Remove(rmvUser);
					db.SaveChanges();
				}
			}
		}
		public static string CalculateMD5Hash(string input)

		{

			// step 1, calculate MD5 hash from input

			MD5 md5 = MD5.Create();

			byte[] inputBytes = Encoding.ASCII.GetBytes(input);

			byte[] hash = md5.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)

			{

				sb.Append(hash[i].ToString("X2"));

			}

			return sb.ToString();

		}

	}
}