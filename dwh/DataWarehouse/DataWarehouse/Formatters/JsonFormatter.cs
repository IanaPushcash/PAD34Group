using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataWarehouse.Formatters
{
	class JsonFormatter:Formatter
	{
		public override string ToFormat(object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		public override T ToObject<T>(string str)
		{
			return JsonConvert.DeserializeObject<T>(str);
		}

		public JsonFormatter(string format)
		{
			FormatName = format;
		}
	}
}
