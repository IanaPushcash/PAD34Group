using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	class SearchTripResult
	{
		public int CountTrips { get; set; }
		public List<Trip> Trips { get; set; }
	}
}
