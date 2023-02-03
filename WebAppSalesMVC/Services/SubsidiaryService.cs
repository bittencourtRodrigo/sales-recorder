using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebAppSalesMVC.Services.Exceptions;

namespace WebAppSalesMVC.Services
{
    public class SubsidiaryService
    {
        private readonly WebAppSalesMVCContext _context;

        public SubsidiaryService(WebAppSalesMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Subsidiary>> GetSubsidiariesAsync()
        {
            return await _context.Subsidiary.Include(obj => obj.State).ToListAsync();
        }

        public async Task AddNewSubsidiaryAsync(Subsidiary subsidiary)
        {
            _context.Subsidiary.Add(subsidiary);
            await _context.SaveChangesAsync();
        }

        public async Task<Subsidiary> GetByIdAsync(int id)
        {
            return await _context.Subsidiary.Include(obj => obj.State).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var subsidiary = await GetByIdAsync(id);
                _context.Subsidiary.Remove(subsidiary);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("You have tried to exclude a subsidiary with sales record");
            }

        }

        public async Task UpdateAsync(Subsidiary subsidiary)
        {
            var exists = await _context.Subsidiary.AnyAsync(x => x.Id == subsidiary.Id);
            if (!exists)
            {
                throw new NotFoundExeption("Some data was not found");
            }

            try
            {
                _context.Update(subsidiary); //May return concurrency error
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message); //to keep segregation and return a possible service class error, we re-post the error from it
            }
        }
    }
}
