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
    public class ButtonUIRepository:RepositoryBase<ButtonUI>,IButtonUIRepository
    {
        private readonly ApplicationDbContext _context;
        public ButtonUIRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public ButtonUI FindByTextAsync(string id)
        {
            return _context.ButtonUIs.First(a => a.Text == id);
        }
    }
}
