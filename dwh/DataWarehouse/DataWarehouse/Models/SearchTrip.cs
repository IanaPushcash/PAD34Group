using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	class SearchTrip:Pagination
	{
		public long IdCityFrom { get; set; }
		public long IdCityTo { get; set; }
		public DateTime TripDate { get; set; }
	}
}
