using SalesWeb.ASPNETCORE.Data;
using System.Collections.Generic;
using SalesWeb.ASPNETCORE.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWeb.ASPNETCORE.Service.Exceptions;
using System.Threading.Tasks;

namespace SalesWeb.ASPNETCORE.Service
{
	public class SellersService
	{
		private readonly SalesWebASPNETCOREContext _context;

		public SellersService(SalesWebASPNETCOREContext context)
		{
			_context = context;
		}

		public async Task<List<Sellers>> FindAllAsync()
		{
			return await _context.Sellers.ToListAsync();
		}

		public async Task InsertAsync(Sellers obj)
		{
			_context.Add(obj);
			
			await _context.SaveChangesAsync();
			
		}
		public async Task<Sellers> FindByIdAsync(int id)
        {
			return await _context.Sellers
				.Include(obj =>obj.departaments)
				.FirstOrDefaultAsync(obj => obj.id == id);
        }

		public	async Task RemoveAsync(int id)
        {
			var obj = await _context.Sellers.FindAsync(id);
			_context.Remove(obj);
			await _context.SaveChangesAsync();
        }
		public async Task UpdateAsync(Sellers obj)
        {
			bool hasAny = await _context.Sellers.AnyAsync(x => x.id == obj.id);

			if (!hasAny) // Any() - verifica no banco se existe alguma campo informado no precate.
			{
				throw new NotFoundException("Id not Found");
            }

			try
			{
				_context.Update(obj);
				await _context.SaveChangesAsync();
			}
			catch(DbUpdateConcurrencyException e)
            {
				throw new DbConcurrencyException(e.Message);
            }


		}
	}
}
