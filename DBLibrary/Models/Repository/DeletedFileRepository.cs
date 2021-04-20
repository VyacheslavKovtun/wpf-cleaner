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
    public class DeletedFileRepository : BaseRepository<DeletedFile, int>
    {
        public DeletedFileRepository(DatabaseContext ctx) : base(ctx) { }

        public void Create(DeletedFile item)
        {
            ctx.Entry(item).State = EntityState.Added;
            ctx.SaveChanges();
        }

        public async override Task<DeletedFile> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(df => df.Id == id);
        }

        public async override Task UpdateAsync(DeletedFile item)
        {
            DeletedFile delFile = await GetAsync(item.Id);

            delFile.FileName = item.FileName;
            delFile.FullPath = item.FullPath;
            delFile.Extension = item.Extension;
            delFile.Size = item.Size;
            delFile.Deleted = item.Deleted;

            await ctx.SaveChangesAsync();
        }
    }
}
