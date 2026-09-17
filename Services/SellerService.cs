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
            seller.Department = _context.Departments.First();
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }
    }
}