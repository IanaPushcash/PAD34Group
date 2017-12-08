using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Models;

namespace DataWarehouse
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Port: ");
			var port = int.Parse(Console.ReadLine());
			Console.WriteLine("Ip: ");
			var ip = Console.ReadLine();
			var listener = new WebListener(port, ip);
			Task.Run(() => listener.Listen());
			//using (var db = new DatabaseContext())
			//{

			//	db.Users.Add(new User()
			//	{
			//		Created = DateTime.Now,
			//		Email = "anny_ok_94@mail.ru",
			//		Id = 1,
			//		Login = "Iana",
			//		Password = "1234"
			//	});
			//	db.SaveChanges();
			//}
			//using (var db = new DatabaseContext())
			//{

			//	var x = db.Users.First();
			//}

			Console.ReadLine();
		}
	}
}
