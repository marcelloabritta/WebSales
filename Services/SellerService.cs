using System.Data;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services.Exceptions;

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
            return await _context.Sellers.Include(seller => seller.Department).FirstOrDefaultAsync(seller => seller.Id == id);

        }

        public async Task Update(Seller seller)
        {
            bool hasAny = await _context.Sellers.AnyAsync(s => s.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DBConcurrencyException(e.Message);
            }

        }

        public async Task Remove(int id)
        {
            try
            {
                var seller = await _context.Sellers.FindAsync(id);
                _context.Sellers.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can´t delete seller because he/she has sales");
            }
        }
    }
}