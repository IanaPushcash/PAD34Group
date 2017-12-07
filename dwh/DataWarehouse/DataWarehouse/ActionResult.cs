using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Formatters;

namespace DataWarehouse
{
	abstract class ActionResult
	{
		public Formatter ResponseFormatter { get; set; }
		public abstract void ExecuteResult(HttpListenerResponse response);
	}

	class HtmlPageResult : ActionResult
    {
        private string htmlCode { get; set; }
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

	class ObjectResult : ActionResult
	{
		private object obj { get; set; }

		public ObjectResult(object obj)
		{
			this.obj = obj;
		}
		public override void ExecuteResult(HttpListenerResponse response)
		{

			response.StatusCode = 200; // HttpStatusCode.OK;
			response.ContentType = ResponseFormatter.FormatName;
			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ResponseFormatter.ToFormat(obj));
			response.ContentLength64 = buffer.Length;
			Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);
			output.Close();
		}
	}

	class SuccessResult : ActionResult
	{
		private bool success;

		public SuccessResult(bool success)
		{
			this.success = success;
		}

		public override void ExecuteResult(HttpListenerResponse response)
		{
			response.StatusCode = 200; // HttpStatusCode.OK;
			response.ContentType = ResponseFormatter.FormatName;
			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ResponseFormatter.ToFormat(success));
			response.ContentLength64 = buffer.Length;
			Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);
			output.Close();
		}
	}

	class ErrorResult : ActionResult
	{
		private string error;
		private int errorCode;

		public ErrorResult(string error, int errorCode)
		{
			this.error = error;
			this.errorCode = errorCode;
		}

		public override void ExecuteResult(HttpListenerResponse response)
		{
			response.StatusCode = errorCode; // HttpStatusCode.OK;
			response.ContentType = ResponseFormatter.FormatName;
			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ResponseFormatter.ToFormat(error));
			response.ContentLength64 = buffer.Length;
			Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);
			output.Close();
		}
	}
}
