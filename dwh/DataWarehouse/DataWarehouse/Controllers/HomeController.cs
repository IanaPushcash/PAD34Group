using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Annotations;

namespace DataWarehouse.Controllers
{
	class HomeController:Controller
	{
		[GET]
		public override ActionResult Index()
		{
			return new HtmlPageResult(File.ReadAllText("Views/Home/Index.html"));
		}
	}
}
