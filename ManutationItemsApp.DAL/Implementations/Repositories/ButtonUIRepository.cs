using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class ButtonUIRepository:RepositoryBase<ButtonUI>,IButtonUIRepository
    {
        public ButtonUIRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
