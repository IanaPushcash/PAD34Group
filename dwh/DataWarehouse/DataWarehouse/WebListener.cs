using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DataWarehouse.RequestHandler;

namespace DataWarehouse
{
	class WebListener
	{
		
		private int port { get; set; }
		private string address { get; set; }

		public WebListener(int port, string address)
		{
			this.port = port;
			this.address = address;
		}

		//public void Start()
		//{
		//	try
		//	{
		//		listener = new TcpListener(IPAddress.Parse(address), port);
		//		listener.Start();

		//		while (true)
		//		{
		//			TcpClient client = listener.AcceptTcpClient();
		//			WebClient clientObj = new WebClient();

		//			// создаем новый поток для обслуживания нового клиента
		//			Thread clientThread = new Thread(new ThreadStart(clientObj.Process));
		//			clientThread.Start();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex);
		//	}
		//	finally
		//	{
		//		listener?.Stop();
		//	}
		//}

		public async Task Listen()
		{
			try
			{
				HttpListener listener = new HttpListener();
				listener.Prefixes.Add($"http://{address}:{port}/");
				listener.Start();
				Console.WriteLine("Ожидание подключений...");

				while (true)
				{
					HttpListenerContext context = await listener.GetContextAsync();
					Task.Run(()=> Process(context));
					//HttpListenerRequest request = context.Request;
					//HttpListenerResponse response = context.Response;

					//string responseString = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
					//byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
					//response.ContentLength64 = buffer.Length;
					//Stream output = response.OutputStream;
					//output.Write(buffer, 0, buffer.Length);
					//output.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
