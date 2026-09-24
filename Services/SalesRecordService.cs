using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;

namespace SalesWeb.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebContext _context;

        public SalesRecordService(SalesWebContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from salesRecord in _context.SalesRecords select salesRecord;

            if (minDate.HasValue)
            {
                result = result.Where(sr => sr.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(sr => sr.Date <= maxDate.Value);
            }

            return await result.Include(sr => sr.Seller)
                         .Include(sr => sr.Seller.Department)
                         .OrderByDescending(sr => sr.Date)
                         .ToListAsync();

        }
    }
}