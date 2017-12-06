using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataWarehouse.Formatters
{
	class XmlFormatter:Formatter
	{
		public override string ToFormat(object obj)
		{
			XmlSerializer formatter = new XmlSerializer(obj.GetType());
			using (StringWriter textWriter = new StringWriter())
			{
				formatter.Serialize(textWriter, obj);
				return textWriter.ToString();
			}
		}

		public override T ToObject<T>(string str)
		{
			XmlSerializer formatter = new XmlSerializer(typeof(T));
			using (StringReader textReader = new StringReader(str))
			{
				return (T)formatter.Deserialize(textReader);
			}
		}
		public XmlFormatter(string format)
		{
			FormatName = format;
		}
	}
}
