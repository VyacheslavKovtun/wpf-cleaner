using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFCleaner.ViewModels.Models
{
    public class DeletedFileViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string fileName;
        private string fullPath;
        private string extension;
        private long size;
        private DateTime deleted;

        public string FileName
        {
            get => fileName;
            set
            {
                this.fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string FullPath
        {
            get => fullPath;
            set
            {
                this.fullPath = value;
                OnPropertyChanged(nameof(FullPath));
            }
        }

        public string Extension
        {
            get => extension;
            set
            {
                this.extension = value;
                OnPropertyChanged(nameof(Extension));
            }
        }

        public long Size
        {
            get => size;
            set
            {
                this.size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        public DateTime Deleted
        {
            get => deleted;
            set
            {
                this.deleted = value;
                OnPropertyChanged(nameof(Deleted));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
