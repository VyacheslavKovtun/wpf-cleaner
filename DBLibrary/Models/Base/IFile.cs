using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Base
{
    public interface IFile
    {
        string FileName { get; set; }

        string FullPath { get; set; }
    }
}
