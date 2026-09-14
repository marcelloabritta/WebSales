using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Models;
using SalesWeb.Models.Enums;

namespace SalesWeb.Data
{
    public class SeedingService
    {
        private SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public async Task SeedASync()
        {
            if (_context.Departments.Any() || _context.Sellers.Any() || _context.SalesRecords.Any())
            {
                return; // DB has been seed
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "alexp@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2026, 9, 14), 11000.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2026, 9, 12), 3500.0, SaleStatus.Billed, s3);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2026, 9, 10), 1400.0, SaleStatus.Billed, s2);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2026, 9, 8), 5500.0, SaleStatus.Billed, s5);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2026, 9, 5), 2000.0, SaleStatus.Billed, s1);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2026, 9, 2), 3000.0, SaleStatus.Pending, s4);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2026, 9, 1), 13000.0, SaleStatus.Billed, s2);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2026, 8, 28), 4000.0, SaleStatus.Billed, s6);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2026, 8, 25), 8500.0, SaleStatus.Canceled, s3);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2026, 8, 22), 12000.0, SaleStatus.Billed, s5);
            SalesRecord sr11 = new SalesRecord(11, new DateTime(2026, 8, 20), 7000.0, SaleStatus.Billed, s1);
            SalesRecord sr12 = new SalesRecord(12, new DateTime(2026, 8, 18), 4500.0, SaleStatus.Billed, s2);
            SalesRecord sr13 = new SalesRecord(13, new DateTime(2026, 8, 15), 6000.0, SaleStatus.Billed, s4);
            SalesRecord sr14 = new SalesRecord(14, new DateTime(2026, 8, 12), 9000.0, SaleStatus.Pending, s5);
            SalesRecord sr15 = new SalesRecord(15, new DateTime(2026, 8, 10), 2200.0, SaleStatus.Billed, s6);
            SalesRecord sr16 = new SalesRecord(16, new DateTime(2026, 8, 8), 15000.0, SaleStatus.Billed, s3);
            SalesRecord sr17 = new SalesRecord(17, new DateTime(2026, 8, 5), 3100.0, SaleStatus.Billed, s1);
            SalesRecord sr18 = new SalesRecord(18, new DateTime(2026, 8, 2), 5000.0, SaleStatus.Billed, s4);
            SalesRecord sr19 = new SalesRecord(19, new DateTime(2026, 7, 30), 8000.0, SaleStatus.Canceled, s2);
            SalesRecord sr20 = new SalesRecord(20, new DateTime(2026, 7, 28), 4800.0, SaleStatus.Billed, s5);
            SalesRecord sr21 = new SalesRecord(21, new DateTime(2026, 7, 25), 9500.0, SaleStatus.Billed, s1);
            SalesRecord sr22 = new SalesRecord(22, new DateTime(2026, 7, 22), 1600.0, SaleStatus.Billed, s6);
            SalesRecord sr23 = new SalesRecord(23, new DateTime(2026, 7, 20), 11000.0, SaleStatus.Billed, s3);
            SalesRecord sr24 = new SalesRecord(24, new DateTime(2026, 7, 18), 3700.0, SaleStatus.Billed, s4);
            SalesRecord sr25 = new SalesRecord(25, new DateTime(2026, 7, 15), 8200.0, SaleStatus.Billed, s2);
            SalesRecord sr26 = new SalesRecord(26, new DateTime(2026, 7, 12), 6500.0, SaleStatus.Billed, s5);
            SalesRecord sr27 = new SalesRecord(27, new DateTime(2026, 7, 10), 4100.0, SaleStatus.Pending, s1);
            SalesRecord sr28 = new SalesRecord(28, new DateTime(2026, 7, 8), 13500.0, SaleStatus.Billed, s3);
            SalesRecord sr29 = new SalesRecord(29, new DateTime(2026, 7, 5), 2900.0, SaleStatus.Billed, s6);
            SalesRecord sr30 = new SalesRecord(30, new DateTime(2026, 7, 2), 7300.0, SaleStatus.Billed, s4);

            _context.Departments.AddRange(d1, d2, d3, d4);
            _context.Sellers.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecords.AddRange(
                sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10,
                sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20,
                sr21, sr22, sr23, sr24, sr25, sr26, sr27, sr28, sr29, sr30
            );

            await _context.SaveChangesAsync();
        }
    }
}