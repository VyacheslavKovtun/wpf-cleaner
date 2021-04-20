using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Base
{
    public abstract class BaseEntity<T> where T: struct
    {
        public T Id { get; set; }
    }
}
