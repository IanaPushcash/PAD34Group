using System.Net;

namespace DataWarehouse
{
	internal class RequestHandler
	{
		public static void Process(HttpListenerContext context)
		{
			var request = context.Request;
			var path = request.Url.LocalPath;
			var pathSegments = path.Split('/');
			var requestMethod = request.HttpMethod;
			var requestDataFormat = request.ContentType;

			var controller = MethodInvoker.GetController(pathSegments);


		}
	}
}