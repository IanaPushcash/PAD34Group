using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	public class City
	{
		private long id;
		[Key]
		public long Id {
			get { return id; }
			set
			{
				id = value;
				href = "/api/city/"+ value;
			} }
		[StringLength(255)]
		public string CityName { get; set; }
		[NotMapped]
		public string href { get; set; }
	}
}
