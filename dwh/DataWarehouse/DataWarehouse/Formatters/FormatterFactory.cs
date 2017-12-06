using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Formatters
{
	class FormatterFactory
	{
		public static Formatter Create(string formatName)
		{
			switch (formatName)
			{
				case "text/json": return	new JsonFormatter(formatName);
				case "text/xml": return new XmlFormatter(formatName);
				case "text/yaml": return new YamlFormatter(formatName);
				default: return null;
			}
		}
	}
}
