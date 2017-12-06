using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Formatters
{
	abstract class Formatter
	{
		public string FormatName { get; set; }
		public abstract string ToFormat(object obj);
		public abstract T ToObject<T>(string str);
	}
}
