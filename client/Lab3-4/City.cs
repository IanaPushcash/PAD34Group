using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	public class City
	{
		[Key]
		public long Id { get; set; }
		[StringLength(255)]
		public string CityName { get; set; }
	}
}
