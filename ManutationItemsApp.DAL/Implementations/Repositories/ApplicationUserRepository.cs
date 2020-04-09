﻿using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager,ApplicationDbContext context):base(context)
        {
            _userManager = userManager;
        }

        public async Task CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteUser(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task EditAsync(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task<List<ApplicationUser>> GetAllFreeUsersAsync()
        {
            List<string> userIds = await RepositoryContext.UserRoles.Where(a => a.RoleId == "21c13c40-fb65-4ed3-9d42-677990233d86")
                .Select(b=>b.UserId)
                .ToListAsync();
            List<ApplicationUser> listUsers = RepositoryContext.Users.Where(a => userIds.Any(c => c == a.Id)).ToList();
            return listUsers;//.Where(u => u.ManutationStages.Count(m => m.ManutationStage.Name != "Started"||
            //m.ManutationStage.Name != "Suspended"|| m.ManutationStage.Name != "Resumed") == 0).ToList();
        }

        public async Task<List<string>> GetAllFreeUsersNamesAsync()
        {
            List<string> userIds = await RepositoryContext.UserRoles.Where(a => a.RoleId == "21c13c40-fb65-4ed3-9d42-677990233d86")
                .Select(b => b.UserId)
                .ToListAsync();
            List<string> listUsers = RepositoryContext.Users.Where(a => userIds.Any(c => c == a.Id)).Select(a=>a.UserName).ToList();
            return listUsers;//.Where(u => u.ManutationStages.Count(m => m.ManutationStage.Name != "Started"||
            //m.ManutationStage.Name != "Suspended"|| m.ManutationStage.Name != "Resumed") == 0).ToList();
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserAsync(string userEmail)
        {
            return await _userManager.FindByEmailAsync(userEmail);
        }

        public async Task<ApplicationUser> GetUserByID(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
