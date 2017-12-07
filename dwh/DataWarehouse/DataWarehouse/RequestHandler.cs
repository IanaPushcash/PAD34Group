using System;
using System.IO;
using System.Net;
using System.Text;
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
			var content = GetContent(request);
			
			var methodInvoker = new MethodInvoker(request.AcceptTypes, request.ContentType);
			var controller = methodInvoker.GetController(pathSegments);
			ActionResult actionResult;
			if (controller != null)
			{ actionResult = methodInvoker.Invoke(controller, requestMethod, requestDataFormat, request.QueryString, pathSegments, content);}
			else actionResult = new ErrorResult("Wrong request. Controller doesn't exist", 400);
			//var actionResult = ((HomeController) controller).Index();
			actionResult.ExecuteResult(context.Response);

		}
		private static string GetContent(HttpListenerRequest Request)
		{
			string documentContents;
			using (Stream receiveStream = Request.InputStream)
			{
				using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
				{
					documentContents = readStream.ReadToEnd();
				}
			}
			return documentContents;
		}
	}
}