using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFCleaner.Commands;
using WPFCleaner.ViewModels.Models;

namespace WPFCleaner.ViewModels.View
{
    public class CleanOperativeViewModel: INotifyPropertyChanged
    {
        #region Data
        public ObservableCollection<ProcessViewModel> Processes { get; set; } = new ObservableCollection<ProcessViewModel>();

        private ProcessViewModel selectedProcess;
        public ProcessViewModel SelectedProcess
        {
            get => selectedProcess;
            set
            {
                this.selectedProcess = value;
                OnPropertyChanged(nameof(SelectedProcess));
            }
        }

        #endregion

        #region Commands

        private ActionCommand closeProcessCommand;
        public ActionCommand CloseProcessCommand
        {
            get => closeProcessCommand ?? (closeProcessCommand = new ActionCommand(obj =>
            {
                if(obj != null)
                {
                    try
                    {
                        ProcessViewModel process = obj as ProcessViewModel;
                        var idx = Processes.IndexOf(process);

                        CloseProcesses(process.ProcessName);

                        Processes.Remove(process);

                        if (Processes.Count > 0 && idx != -1)
                        {
                            if (idx == Processes.Count - 1)
                            {
                                SelectedProcess = Processes.Last();
                            }

                            else if (idx == 0)
                            {
                                SelectedProcess = Processes.First();
                            }
                            else
                            {
                                SelectedProcess = Processes[idx - 1];
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }));
        }

        #endregion

        public CleanOperativeViewModel()
        {
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            var processes = Process.GetProcesses(); 

            foreach(var process in processes)
            {
                try
                {
                    ProcessViewModel processViewModel = new ProcessViewModel()
                    {
                        ProcessName = process.ProcessName,
                        Priority = process.PriorityClass,
                        HandleCount = process.HandleCount,
                        StartTime = process.StartTime,
                        MemorySize = process.PagedSystemMemorySize64
                    };

                    Processes.Add(processViewModel);
                }
                catch(Exception ex) { }
            }
        }

        private void CloseProcesses(string name)
        {
            var processes = Process.GetProcessesByName(name);

            foreach (var proc in processes)
            {
                proc.Kill();
            }
        }

        public void AutoCloseProcesses()
        {
            try
            {
                var processes = Process.GetProcesses().Where(p => p.PriorityClass == ProcessPriorityClass.BelowNormal
                || p.PriorityClass == ProcessPriorityClass.Idle);

                foreach (var process in processes)
                {
                    process.Kill();

                    var proc = Processes.FirstOrDefault(p => p.ProcessName == process.ProcessName);

                    Processes.Remove(proc);
                }
            }
            catch(Exception ex) { }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
