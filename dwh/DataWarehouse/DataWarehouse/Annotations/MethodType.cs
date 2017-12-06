using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Annotations
{
	class MethodType : Attribute
	{
		public string MType { get; set; }

		public MethodType(string method)
		{
			MType = method;
		}
	}
}
