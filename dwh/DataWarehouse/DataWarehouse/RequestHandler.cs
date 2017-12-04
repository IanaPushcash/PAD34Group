using System;
using System.Net;
using DataWarehouse.Controllers;

namespace DataWarehouse
{
	internal class RequestHandler
	{
		public static void Process(HttpListenerContext context)
		{
			var request = context.Request;
			var path = request.Url.LocalPath;
			var pathSegments = path.Split(new []{"/"}, StringSplitOptions.RemoveEmptyEntries);
			var requestMethod = request.HttpMethod;
			var requestDataFormat = request.ContentType;

			var controller = MethodInvoker.GetController(pathSegments);
			var actionResult = ((HomeController) controller).Index();
			actionResult.ExecuteResult(context.Response);

		}
	}
}