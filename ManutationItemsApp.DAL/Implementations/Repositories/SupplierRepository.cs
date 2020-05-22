using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool Any(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public async Task<Supplier> FindByName(string name)
        {
            return await _context.Suppliers.FirstAsync(a => a.Name == name);
        }

        public async Task<List<string>> GetSupplierNames()
        {
          return await _context.Suppliers.Select(a => a.Name).ToListAsync();
           
        }

        public override void Update(Supplier supplier)
        {
            var objFromDb = _context.Suppliers.FirstOrDefault(s => s.Id ==supplier.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = supplier.Name;
                objFromDb.Nationality = supplier.Nationality;
                objFromDb.Address = supplier.Address;
                objFromDb.CommercialRefferent = supplier.CommercialRefferent;
                objFromDb.PhoneCom = supplier.PhoneCom;
                objFromDb.EmailCom = supplier.EmailCom;
                objFromDb.TechnicalRefferent = supplier.TechnicalRefferent;
                objFromDb.PhoneTechn = supplier.PhoneTechn;
                objFromDb.EmailTechn = supplier.EmailTechn;
                objFromDb.ApprovTemp = supplier.ApprovTemp;
                //objFromDb.Name = supplier.Name;

                
            }
        }
    }
}
