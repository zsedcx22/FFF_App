using FFF_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FFF_App.Services
{
    public interface IScreeningDataStore<T> : IDataStore<T>
    {
        Task<IEnumerable<Film>> GetFilmsAsync();
    }
}
