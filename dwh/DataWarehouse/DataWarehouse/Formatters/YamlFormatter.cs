using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Formatters
{
	class YamlFormatter:Formatter
	{
		public override string ToFormat(object obj)
		{
			throw new NotImplementedException();
		}

		public override T ToObject<T>(string str)
		{
			throw new NotImplementedException();
		}
		public YamlFormatter(string format)
		{
			FormatName = format;
		}
	}
}
