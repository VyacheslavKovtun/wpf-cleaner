using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFCleaner.ViewModels.Models
{
    public class ClearedCookieFileViewModel: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string fileName;
        private string fullPath;
        private string browserName;
        private DateTime cleared;

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

        public string BrowserName
        {
            get => browserName;
            set
            {
                this.browserName = value;
                OnPropertyChanged(nameof(BrowserName));
            }
        }

        public DateTime Cleared
        {
            get => cleared;
            set
            {
                this.cleared = value;
                OnPropertyChanged(nameof(Cleared));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
