using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Models;

namespace WebAppSalesMVC.Services
{
    public class SalesRecordService
    {
        private readonly WebAppSalesMVCContext _context;

        public SalesRecordService(WebAppSalesMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> GetSalesByDateAsync(DateTime? dateMin, DateTime? dateMax)
        {
            var request = from obj in _context.SalesRecord select obj;

            if (dateMin.HasValue)
            {
                request = request.Where(x => x.Date >= dateMin.Value.Date);
            }
            if (dateMax.HasValue)
            {
                request = request.Where(x => x.Date <= dateMax.Value.Date);
            }

            return await request.Include(x => x.Subsidiary)
                .Include(x => x.Subsidiary.State)
                .OrderBy(x => x.Date)
                .ToListAsync();
        }
        
        public async Task<List<IGrouping<State, SalesRecord>>> GetSalesStatesByDateAsync(DateTime? dateMin, DateTime? dateMax)
        {
            var request = from obj in _context.SalesRecord select obj;

            if (dateMin.HasValue)
            {
                request = request.Where(x => x.Date >= dateMin.Value.Date);
            }
            if (dateMax.HasValue)
            {
                request = request.Where(x => x.Date <= dateMax.Value.Date);
            }

            return await request.Include(x => x.Subsidiary)
                .Include(x => x.Subsidiary.State)
                .OrderBy(x => x.Date)
                .GroupBy(x => x.Subsidiary.State)
                .ToListAsync();
        }

        public void CreateSale(SalesRecord sale)
        {
            _context.SalesRecord.Add(sale);
            _context.SaveChanges();
        }
    }
}
