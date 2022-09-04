using SalesWeb.ASPNETCORE.Data;
using System.Collections.Generic;
using SalesWeb.ASPNETCORE.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWeb.ASPNETCORE.Service.Exceptions;

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
		public Sellers FindById(int id)
        {
			return _context.Sellers
				.Include(obj =>obj.departaments)
				.FirstOrDefault(obj => obj.id == id);
        }

		public	void Remove(int id)
        {
			var obj = _context.Sellers.Find(id);
			_context.Remove(obj);
			_context.SaveChanges();
        }
		public void Update(Sellers obj)
        {
			if(!_context.Sellers.Any(x => x.id == obj.id)) // Any() - verifica no banco se existe alguma campo informado no precate.
			{
				throw new NotFoundException("Id not Found");
            }

			try
			{
				_context.Update(obj);
				_context.SaveChanges();
			}
			catch(DbUpdateConcurrencyException e)
            {
				throw new DbConcurrencyException(e.Message);
            }


		}
	}
}
