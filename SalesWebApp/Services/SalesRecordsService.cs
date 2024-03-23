using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
    public class SalesRecordsService
    {
        private readonly SalesWebAppContext _context;

        public SalesRecordsService(SalesWebAppContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(p => p.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(p => p.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(p => p.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(p => p.Date <= maxDate.Value);
            }

return await result
    .Include(x => x.Seller)
    .Include(x => x.Seller.Department)
    .OrderByDescending(p => p.Date)
    .GroupBy(p => p.Seller.Department)
    .ToListAsync();
        }
    }
}
