using DBLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Entities
{
    public class DeletedFile: BaseEntity<int>, IFile
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime Deleted { get; set; }
    }
}
