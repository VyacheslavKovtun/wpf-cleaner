using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace WPFCleaner.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<FileInfo> AddFileInfoRange(this ObservableCollection<FileInfo> collection, List<FileInfo> list)
        {
            foreach (var item in list)
            {
                collection.Add(item);
            }
            return collection;
        }
    }
}
