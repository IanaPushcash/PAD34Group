using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	class SearchUserTrips:Pagination
	{
		public long IdUser { get; set; }
	}
}
