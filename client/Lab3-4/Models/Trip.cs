using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	public class Trip
	{
		
		public long Id { get; set; }
		
		public long IdUser { get; set; }
		
		public long IdCityFrom { get; set; }
		
		public long IdCityTo { get; set; }
		public float Price { get; set; }
		
		public string FromPlace { get; set; }
		public DateTime StartTime { get; set; }
		public int MinutesToDest { get; set; }
		public DateTime Created { get; set; }
		public bool IsActive { get; set; }

		public User User { get; set; }
		public City CityFrom { get; set; }
		public City CityTo { get; set; }
	}
}
