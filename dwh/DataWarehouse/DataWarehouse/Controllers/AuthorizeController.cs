using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Annotations;
using DataWarehouse.Models;

namespace DataWarehouse.Controllers
{
	class AuthorizeController:Controller
	{
		[MethodType("POST")]
		public ActionResult Login(User user)
		{
			try
			{
				using (var db = new DatabaseContext())
				{
					var x = db.Users.Where(u => u.Login == user.Login &&
					                            u.Password == CalculateMD5Hash(user.Password + u.Created.ToString("yy-MM-dd"))).ToList();
					if (x.Count == 1)
						return new ObjectResult(x);
				}
				return new SuccessResult(false);
			}
			catch (Exception e)
			{
				return new ErrorResult(e.Message, 418);
			}
		}

		[MethodType("POST")]
		public ActionResult Register(User newUser)
		{
			try
			{
				using (var db = new DatabaseContext())
				{
					newUser.Created = DateTime.Now;
					newUser.Password = CalculateMD5Hash(newUser.Password + newUser.Created.ToString("yy-MM-dd"));
					db.Users.Add(newUser);
					db.SaveChanges();
					return new ObjectResult(newUser);
				}
			}
			catch (Exception e)
			{
				return new ErrorResult(e.Message, 406);
			}
		}
		private string CalculateMD5Hash(string input)

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
