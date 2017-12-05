using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouse.Models
{
	class DatabaseContext: DbContext
	{
		public DatabaseContext()
			:base("DbConnection")
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Trip> Trips { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}
	}
}
