using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Models;

namespace WebAppSalesMVC.Services
{
    public class StateService
    {
        private readonly WebAppSalesMVCContext _context;

        public StateService(WebAppSalesMVCContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetStatesAsync()
        {
            return await _context.State.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
