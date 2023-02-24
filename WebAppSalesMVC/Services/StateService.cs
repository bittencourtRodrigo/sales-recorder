using Microsoft.EntityFrameworkCore;
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

        public async Task<List<State>> GetStatesIncSubsAsync()
        {
            return await _context.State.Include(x => x.Subsidiaries).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<State> GetByIdAsync(int Id)
        {
            return await _context.State.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<State>> GetStatesAsync()
        {
            return await _context.State.OrderBy(x => x.Name).ToListAsync();
        }
    }
}