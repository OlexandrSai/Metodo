using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
   
    public class ToolRepository:RepositoryBase<Tool>,IToolRepository
    {
        private readonly ApplicationDbContext _context;
        public ToolRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Tools.AnyAsync(t=>t.Id==id);
        }

        public void Update(Tool tool)
        {
            //var objFromDb = _context.Suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            //if (objFromDb != null)
            //{
            //    objFromDb.Name = supplier.Name;
            //    objFromDb.Nationality = supplier.Nationality;
            //    objFromDb.Address = supplier.Address;
            //    objFromDb.CommercialRefferent = supplier.CommercialRefferent;
            //    objFromDb.PhoneCom = supplier.PhoneCom;
            //    objFromDb.EmailCom = supplier.EmailCom;
            //    objFromDb.TechnicalRefferent = supplier.TechnicalRefferent;
            //    objFromDb.PhoneTechn = supplier.PhoneTechn;
            //    objFromDb.EmailTechn = supplier.EmailTechn;
            //    objFromDb.ApprovTemp = supplier.ApprovTemp;
            //    //objFromDb.Name = supplier.Name;


            }
        }
}
