using DBLibrary.Models.Base;
using DBLibrary.Models.DBContext;
using DBLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Repository
{
    public class ClearedCookieFileRepository: BaseRepository<ClearedCookieFile, int>
    {
        public ClearedCookieFileRepository(DatabaseContext ctx): base(ctx) { }

        public async override Task<ClearedCookieFile> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(cf => cf.Id == id);
        }

        public async override Task UpdateAsync(ClearedCookieFile item)
        {
            ClearedCookieFile clearedCookieFile = await GetAsync(item.Id);

            clearedCookieFile.FileName = item.FileName;
            clearedCookieFile.FullPath = item.FullPath;
            clearedCookieFile.BrowserName = item.BrowserName;
            clearedCookieFile.Cleared = item.Cleared;

            await ctx.SaveChangesAsync();
        }
    }
}
