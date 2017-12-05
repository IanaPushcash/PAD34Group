using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	class Trip
	{
		[Key]
		public long Id { get; set; }
		[ForeignKey("User")]
		public long IdUser { get; set; }
		[ForeignKey("CityFrom")]
		public long IdCityFrom { get; set; }
		[ForeignKey("CityTo")]
		public long IdCityTo { get; set; }
		public float Price { get; set; }
		[StringLength(255)]
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
