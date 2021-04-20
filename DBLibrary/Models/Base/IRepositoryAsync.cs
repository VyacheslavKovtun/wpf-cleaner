using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Base
{
    public interface IRepositoryAsync<TValue, TKey> where TValue: class
        where TKey: struct
    {
        Task CreateAsync(TValue item);
        Task<TValue> GetAsync(TKey id);
        Task<IEnumerable<TValue>> GetAllAsync();
        Task UpdateAsync(TValue item);
        Task DeleteAsync(TKey id);
    }
}
