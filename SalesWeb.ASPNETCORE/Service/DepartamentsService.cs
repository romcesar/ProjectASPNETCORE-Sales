using SalesWeb.ASPNETCORE.Data;
using SalesWeb.ASPNETCORE.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWeb.ASPNETCORE.Service
{
	public class DepartamentsService
	{
		private readonly SalesWebASPNETCOREContext _context;

		public DepartamentsService(SalesWebASPNETCOREContext context)
		{
			_context = context;
		}

		public async Task<List<Departaments>> FindAllAsync()
		{
			return await _context.Departaments.OrderBy(x => x.name).ToListAsync();
			
		}
	}
}
