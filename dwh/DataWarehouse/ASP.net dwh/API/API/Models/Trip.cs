using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	public class Trip
	{
		private long idCityFrom;
		private long idCityTo;
		private long idUser;
		private long id;
		[Key]
		public long Id {
			get
			{
				return id;
			}
			set
			{
				id = value;
				href = "/api/tripall/" + value;
			}
		}
		[ForeignKey("User")]
		public long IdUser {
			get
			{
				return idUser;
			}
			set
			{
				idUser = value;
				hrefIdUser = "/api/user/" + value;
			}
		}
		[ForeignKey("CityFrom")]
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
		[ForeignKey("CityTo")]
		public long IdCityTo
		{
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

		[NotMapped]
		public string hrefCityFrom { get; set; }
		[NotMapped]
		public string hrefCityTo { get; set; }
		[NotMapped]
		public string hrefIdUser { get; set; }
		[NotMapped]
		public string href { get; set; }
	}
}
