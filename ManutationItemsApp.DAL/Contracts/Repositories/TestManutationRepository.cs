
using ManutationItemsApp.DAL.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ManutationItemsApp.DAL.Repositories;
using System.Linq;
using ManutationItemsApp.Domain.Entities;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public class TestManutationRepository: RepositoryBase<TestManutation>, ITestManutationRepository
    {
        private readonly ApplicationDbContext _context;
        public TestManutationRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override void Update(TestManutation testManutation)
        {
            var objFromDb = _context.TestManutations.FirstOrDefault(s => s.Id == testManutation.Id);
            if (objFromDb != null)
            {
                if(testManutation.ImageUrl != null)
                {
                    objFromDb.ImageUrl = testManutation.ImageUrl;
                }

                objFromDb.Name = testManutation.Name;
                objFromDb.AssetId = testManutation.AssetId;


                


            }
        }



    }
}
