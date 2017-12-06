using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	class SearchTrip
	{
		public long? IdCityFrom { get; set; }
		public long? IdCityTo { get; set; }
		public DateTime? TripDate { get; set; }
		public int PageNumber { get; set; }
		public int RecPerPage { get; set; }
	}
}
