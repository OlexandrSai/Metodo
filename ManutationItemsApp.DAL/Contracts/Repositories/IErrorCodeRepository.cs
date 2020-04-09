using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IErrorCodeRepository:IRepositoryBase<ErrorCode>
    {
        public Task<ErrorCode> GetCodeByNameAsync(string name);
        public Task<TypeOfFault> GetFaultByName(string name);
        public Task<List<string>> GetAllNames();
        
        public Task<List<string>> GetAllFaultTypes();
    }
}
