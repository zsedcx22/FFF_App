using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FFF_App.Services
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsByNameAsync(string name);
        Task<IEnumerable<T>> GetItemsByDateAsync(DateTime date);
        Task<IEnumerable<T>> GetItemsByLocationAsync(string venue);
        Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false);
    }
}
