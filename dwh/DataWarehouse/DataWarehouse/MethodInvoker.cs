using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Annotations;
using DataWarehouse.Controllers;
using DataWarehouse.Formatters;
using DataWarehouse.Models;

namespace DataWarehouse
{
	class MethodInvoker
	{
		private Formatter ResponseFormatter;
		private Formatter RequestFormatter;

		public MethodInvoker(string[] acceptTypes, string requestContentType)
		{
			foreach (var acceptType in acceptTypes)
			{
				ResponseFormatter = FormatterFactory.Create(acceptType);
				if (ResponseFormatter != null) break;
			}
			RequestFormatter = FormatterFactory.Create(requestContentType);
		}

		public object GetController(string[] pathSegments)
		{
			try
			{
				if (pathSegments.Length != 0)
					return Assembly.GetExecutingAssembly().CreateInstance($"DataWarehouse.Controllers.{pathSegments[0]}Controller");
					//return Activator.CreateInstance("DataWarehouse.Controllers", pathSegments[0] + "Controller");
				return null;
			}
			catch (Exception e)
			{
				//Console.WriteLine(e);
				return null;
			}
		}

		public ActionResult Invoke(object controller, string requestMethod, string requestDataFormat,
			NameValueCollection requestQueryString, string[] pathSegments, string content)
		{
			try
			{
				if (pathSegments.Length < 2) return new ErrorResult("Method name doesn't exist", 400);
				var methods = controller.GetType()
					.GetMethods()
					.Where(m => m.Name == pathSegments[1]).ToList();
				if (methods.Count < 1) return new ErrorResult("Uncorrect method name", 400);
				methods = methods.Where(m => m.GetCustomAttributes(typeof(MethodType), false).Any(a=>((MethodType)a).MType == requestMethod))
					.ToList();
				if (methods.Count != 1) return new ErrorResult("Uncorrect method", 400);
				var method = methods.First();
				var param = method.GetParameters().ToList().First();
				User u = new User();
				var x = RequestFormatter.ToObject<object>(content);
				Type typeArgument = param.ParameterType;
				Type template = typeof(Request);

				Type genericType = template.MakeGenericType(typeArgument);

				object instance = Activator.CreateInstance(genericType);

				return (ActionResult) methods.First().Invoke(controller, null);
			}
			catch (Exception e)
			{
				return new ErrorResult("", 400);
			}
		}
	}
}
