using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IApplicationUserRepository:IRepositoryBase<ApplicationUser>
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task CreateAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserByNameAsync(string username);
        Task EditAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserAsync(string userEmail);
        Task<ApplicationUser> GetUserByID(string userId);
        Task<IdentityResult> DeleteUser(ApplicationUser user);

        Task<List<ApplicationUser>> GetAllFreeUsersAsync();
        Task<List<string>> GetAllFreeUsersNamesAsync();
        
    }
}
