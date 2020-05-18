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
    public class ButtonUIRepository:RepositoryBase<ButtonUI>,IButtonUIRepository
    {
        public ButtonUIRepository(ApplicationDbContext context):base(context)
        {

        }

        public Task<ButtonUI> FindByTextAsync(string id)
        {
            return RepositoryContext.ButtonUIs.FirstAsync(a => a.Text == id);
        }
    }
}
