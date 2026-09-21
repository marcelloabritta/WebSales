using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;

namespace SalesWeb.Services
{
    public class SellerService
    {
        private readonly SalesWebContext _context;

        public SellerService(SalesWebContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAll()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindById(int id)
        {
            return await _context.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);

        }

        public async Task Remove(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
        }
    }
}