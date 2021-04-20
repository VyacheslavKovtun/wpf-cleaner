using DBLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.DBContext
{
    public class DatabaseContext: DbContext
    {
        public DbSet<DeletedFile> DeletedFiles { get; set; }
        public DbSet<ClearedCookieFile> ClearedCookieFiles { get; set; }

        public DatabaseContext(): base("DefaultConnection") 
        {
            
        }
    }
}
