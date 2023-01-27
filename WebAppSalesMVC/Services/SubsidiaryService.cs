using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Models;
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

        public List<Subsidiary> GetSubsidiaries()
        {
            return _context.Subsidiary.Include(obj => obj.State).ToList();
        }

        public void AddNewSubsidiary(Subsidiary obj)
        {
            obj.State = _context.State.First();
            _context.Subsidiary.Add(obj);
            _context.SaveChanges();
        }

        public Subsidiary GetById(int id)
        {
            return _context.Subsidiary.Include(obj => obj.State).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            _context.Subsidiary.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Update(Subsidiary obj)
        {
            if (!_context.Subsidiary.Any(x =>  x.Id == obj.Id))
            {
                throw new NotFoundExeption("Some data was not found");
            }

            try
            {
                _context.Update(obj); //May return concurrency error
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message); //to keep segregation and return a possible service class error, we re-post the error from it
            }

        }
    }
}
