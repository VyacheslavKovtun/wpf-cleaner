using DBLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Entities
{
    public class ClearedCookieFile : BaseEntity<int>, IFile
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public string BrowserName { get; set; }
        public DateTime Cleared { get; set; }
    }
}
