using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Controllers;

namespace DataWarehouse
{
	class MethodInvoker
	{
		//public static ActionResult Invoke()
		//{
		//	//var methods = controller.GetType()
		//	//	.SelectMany(t => t.GetMethods())
		//	//	.Where(m => m.GetCustomAttributes(typeof(MenuItemAttribute), false).Length > 0)
		//	//	.ToArray();
		//}

		public static object GetController(string[] pathSegments)
		{
			try
			{
				if (pathSegments.Length != 0)
					return Activator.CreateInstance("DataWarehouse.Controllers", pathSegments[0] + "Controller");
				return new HomeController();
			}
			catch (Exception e)
			{
				//Console.WriteLine(e);
				return new HomeController();
			}
		}

		public static ActionResult Invoke(object controller, string requestMethod, string requestDataFormat,
			NameValueCollection requestQueryString, string[] pathSegments)
		{
			MethodInfo method;
			if (pathSegments.Length > 1)
				method = controller.GetType().GetMethods()
					.First(m => m.Name == pathSegments[2] &&
					            m.GetCustomAttributes(Type.GetType($"DataWarehouse.Annotations.{requestMethod}"), false).Length > 0 &&
					            m.GetCustomAttributes(Type.GetType($"DataWarehouse.Annotations.{requestDataFormat}"), false).Length > 0);
			else method = controller.GetType().GetMethods().First(m => m.Name == "Index");
			return (ActionResult)method.Invoke(controller, null);
		}
	}
}
