using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface ITestManutationRepository:IRepositoryBase<TestManutation>
    {
          public void Update(TestManutation testManutation);

        
    }
}
