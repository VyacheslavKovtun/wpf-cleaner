using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFCleaner.ViewModels.Models
{
    public class ProcessViewModel: INotifyPropertyChanged
    {
        private string processName;
        private ProcessPriorityClass priority;
        private int handleCount;
        private DateTime startTime;
        private long memorySize;

        public string ProcessName
        {
            get => processName;
            set
            {
                this.processName = value;
                OnPropertyChanged(nameof(ProcessName));
            }
        }

        public ProcessPriorityClass Priority
        {
            get => priority;
            set
            {
                this.priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }

        public int HandleCount
        {
            get => handleCount;
            set
            {
                this.handleCount = value;
                OnPropertyChanged(nameof(HandleCount));
            }
        }

        public DateTime StartTime
        {
            get => startTime;
            set
            {
                this.startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        public long MemorySize
        {
            get => memorySize;
            set
            {
                this.memorySize = value;
                OnPropertyChanged(nameof(MemorySize));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
