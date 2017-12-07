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
				var inst = Assembly.GetExecutingAssembly().CreateInstance(param.ParameterType + "");
				if (content + "" != "")
				{
					dynamic x = RequestFormatter.ToObject<dynamic>(content);
					foreach (var fieldInfo in inst.GetType().GetProperties())
					{
						fieldInfo.SetValue(inst, x[fieldInfo.Name]?.Value);
					}
				}
				else
				{
					foreach (var fieldInfo in inst.GetType().GetProperties())
					{
						fieldInfo.SetValue(inst, Convert.ChangeType(requestQueryString[fieldInfo.Name], fieldInfo.PropertyType), null);
					}
				}

				//Type template = typeof(Request);
				//var z = fff(param, User);
				//Type genericType = template.MakeGenericType(typeArgument);

				//object instance = Activator.CreateInstance(genericType);
				var result = (ActionResult) methods.First().Invoke(controller, new[] {inst});
				result.ResponseFormatter = ResponseFormatter;
				return result;
			}
			catch (Exception e)
			{
				return new ErrorResult("", 400);
			}
		}

		
	}
}
