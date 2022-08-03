using SalesWeb.ASPNETCORE.Data;
using SalesWeb.ASPNETCORE.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.ASPNETCORE.Service
{
	public class DepartamentsService
	{
		private readonly SalesWebASPNETCOREContext _context;

		public DepartamentsService(SalesWebASPNETCOREContext context)
		{
			_context = context;
		}

		public List<Departaments> FindAll()
		{
			return _context.Departaments.OrderBy(x => x.name).ToList();
			
		}
	}
}
