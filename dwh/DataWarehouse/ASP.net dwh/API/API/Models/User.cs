using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	public class User
	{
		[Key]
		public long Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Login { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[StringLength(50)]
		public string Password { get; set; }
		public DateTime Created { get; set; }
	}
}
