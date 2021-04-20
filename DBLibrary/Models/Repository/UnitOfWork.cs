using DBLibrary.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Repository
{
    public class UnitOfWork: IDisposable
    {
        private static UnitOfWork instance;
        public static UnitOfWork Instance => instance ?? (instance = new UnitOfWork());

        private DatabaseContext ctx;

        private DeletedFileRepository deletedFileRepository;
        private ClearedCookieFileRepository clearedCookieFileRepository;

        public DeletedFileRepository DeletedFileRepository => deletedFileRepository 
            ?? (deletedFileRepository = new DeletedFileRepository(ctx));
        public ClearedCookieFileRepository ClearedCookieFileRepository => clearedCookieFileRepository
            ?? (clearedCookieFileRepository = new ClearedCookieFileRepository(ctx));

        
        private UnitOfWork()
        {
            ctx = new DatabaseContext();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                    ctx.Dispose();

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
