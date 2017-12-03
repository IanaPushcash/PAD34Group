﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse
{
	class Program
	{
		static void Main(string[] args)
		{
			var listener = new WebListener(8888, "localhost");
			Task.Run(() => listener.Listen());
			Console.ReadLine();
		}
	}
}
