using DBLibrary.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Base
{
    public abstract class BaseRepository<TValue, TKey> : IRepositoryAsync<TValue, TKey>
        where TValue : class
        where TKey : struct
    {
        protected DatabaseContext ctx;
        protected DbSet<TValue> table => ctx.Set<TValue>();

        public BaseRepository(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task CreateAsync(TValue item)
        {
            ctx.Entry(item).State = EntityState.Added;
            await ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            TValue item = await GetAsync(id);
            ctx.Entry(item).State = EntityState.Deleted;

            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<TValue>> GetAllAsync()
        {
            return await table.ToListAsync().ConfigureAwait(false);
        }

        public abstract Task<TValue> GetAsync(TKey id);

        public abstract Task UpdateAsync(TValue item);
    }
}
