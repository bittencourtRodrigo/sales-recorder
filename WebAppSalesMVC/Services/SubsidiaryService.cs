using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Models;

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
            return _context.Subsidiary.ToList();
        }

        public void AddNewSubsidiary(Subsidiary obj)
        {
            obj.State = _context.State.First();
            _context.Subsidiary.Add(obj);
            _context.SaveChanges();
        }
    }
}
