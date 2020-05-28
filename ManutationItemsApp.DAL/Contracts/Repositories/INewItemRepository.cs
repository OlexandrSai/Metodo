﻿using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface INewItemRepository: IRepositoryBase<NewItem>
    {
         void Update(NewItem newItem);
    }
}
