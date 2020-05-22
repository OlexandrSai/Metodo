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
    public class ErrorCodeRepository:RepositoryBase<ErrorCode>,IErrorCodeRepository
    {
        private readonly ApplicationDbContext _context;
        public ErrorCodeRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAllNames()
        {
            return await _context.ErrorCodes.Where(a=>a.NotToDisplay==false).OrderBy(a=>a.Name).Select(e => e.Name).ToListAsync();
        }

        public async Task<List<string>> GetAllFaultTypes()
        {
            return await _context.typeOfFaults.OrderBy(a=>a.Name).Select(e => e.Name).ToListAsync();
        }

        public async Task<ErrorCode> GetCodeByNameAsync(string name)
        {
            var errorCode = _context.ErrorCodes.ToList();
            var result = _context.ErrorCodes.Where(a=>a.Name==name).FirstOrDefault();
            return result;
        }

        public async Task<TypeOfFault> GetFaultByName(string name)
        {
             return await _context.typeOfFaults.FirstAsync(a => a.Name == name);
        }
    }
}
