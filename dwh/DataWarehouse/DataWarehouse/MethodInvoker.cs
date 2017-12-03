using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Controllers;

namespace DataWarehouse
{
	class MethodInvoker
	{
		public static void Invoke(HttpListenerContext context)
		{
			
		}

		public static object GetController(string[] pathSegments)
		{
			try
			{
				if (pathSegments.Length != 0)
					return Activator.CreateInstance("DataWarehouse.Controllers", pathSegments[0] + "Controller");
				return new MainController();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new MainController();
			}
		}
	}
}
