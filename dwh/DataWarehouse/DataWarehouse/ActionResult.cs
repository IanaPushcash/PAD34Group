using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse
{
	public abstract class ActionResult
	{
		public abstract void ExecuteResult(HttpListenerResponse response);
	}

	public class HtmlPageResult : ActionResult
    {
        private string htmlCode;
        public HtmlPageResult(string html)
        {
            htmlCode = html;
        }
        public override void ExecuteResult(HttpListenerResponse response)
		{
			response.StatusCode = 200; // HttpStatusCode.OK;
			response.ContentType = "html";
			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(htmlCode);
			response.ContentLength64 = buffer.Length;
			Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);
			output.Close();
		}
	}
}
