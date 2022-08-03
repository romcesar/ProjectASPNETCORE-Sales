using SalesWeb.ASPNETCORE.Data;
using System.Collections.Generic;
using SalesWeb.ASPNETCORE.Models.Entities;
using System.Linq;

namespace SalesWeb.ASPNETCORE.Service
{
	public class SellersService
	{
		private readonly SalesWebASPNETCOREContext _context;

		public SellersService(SalesWebASPNETCOREContext context)
		{
			_context = context;
		}

		public List<Sellers> FindAll()
		{
			return _context.Sellers.ToList();
		}

		public void Insert(Sellers obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
			
		}
	}
}
