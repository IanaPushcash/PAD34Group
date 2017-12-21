using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	public class SearchTrip
	{
		private long idCityFrom;
		private long idCityTo;

		public long IdCityFrom
		{
			get
			{
				return idCityFrom;
			}
			set
			{
				idCityFrom = value;
				hrefCityFrom = "/api/city/" + value;
			}
		}

		public long IdCityTo {
			get
			{
				return idCityTo;
			}
			set
			{
				idCityTo = value;
				hrefCityTo = "/api/city/" + value;
			}
		}
		public DateTime TripDate { get; set; }
		public string hrefCityFrom { get; set; }
		public string hrefCityTo { get; set; }
	}
}
