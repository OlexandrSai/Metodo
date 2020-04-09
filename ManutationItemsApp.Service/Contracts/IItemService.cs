using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManutationItemsApp.Service.Contracts
{
    public interface IItemService
    {
        ServiceState State { get; }
        public Task<List<Item>> GetAllItemsAsync();
        public Task<Item> GetItemByIdAsync(int id);
        public Task<bool> ItemExistsAsync(int id);

        public Task<ServiceState> RemoveItemAsync(int id);

        public Task<Item> AddItemAsync(Item item);

        public Task<Item> EditItemAsync(Item item);
    }
}
