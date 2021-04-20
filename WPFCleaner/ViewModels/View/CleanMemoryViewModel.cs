using DBLibrary.Models.Entities;
using DBLibrary.Models.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPFCleaner.Models;
using WPFCleaner.UserControls;
using WPFCleaner.ViewModels.Models;

namespace WPFCleaner.ViewModels.View
{
    public class CleanMemoryViewModel
    {
        public event Action<bool> RefreshCleanUC;

        UnitOfWork unitOfWork;
        AutoMapperBase autoMapper;

        CleanMemoryUserControl cleanMemoryUC;
        public List<FileInfo> tmpFiles = new List<FileInfo>();
        public List<FileInfo> cookies = new List<FileInfo>();

        public CleanMemoryViewModel() { }

        public CleanMemoryViewModel(CleanMemoryUserControl userControl)
        {
            unitOfWork = UnitOfWork.Instance;
            autoMapper = AutoMapperBase.Instance;
            cleanMemoryUC = userControl;
        }

        public void Clean()
        {
            tmpFiles.Clear();
            cookies.Clear();

            Task.Run(() =>
            {
                GetTempFiles();
                CleanTempFiles();

                GetCookies();
                CleanCookies();
            });
        }

        private void GetTempFiles()
        {
            Task.Run(() =>
            {
                string path = "C:\\Windows\\Temp";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                try
                {
                    tmpFiles.AddRange(dirInfo.GetFiles("*", SearchOption.AllDirectories));
                }
                catch (Exception ex) { }
                RefreshCleanUC?.Invoke(true);
            }).Wait();
        }

        private void GetCookies()
        {
            Task.Run(() =>
            {
                List<string> pathes = new List<string>();

                string chromePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                chromePath += @"\Google\Chrome\User Data\Default\Cookies";
                pathes.Add(chromePath);

                string operaPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                operaPath += @"\Opera Software\Opera Stable\Cookies";
                pathes.Add(operaPath);

                foreach (var path in pathes)
                {
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Exists)
                    {
                        cookies.Add(fileInfo);
                    }
                }

                RefreshCleanUC?.Invoke(true);
            }).Wait();
        }

        private void CleanTempFiles()
        {
            Task.Run(() =>
            {
                try
                {
                    foreach (var file in tmpFiles)
                    {
                        try
                        {
                            DeletedFileViewModel deletedFile = new DeletedFileViewModel()
                            {
                                FileName = file.Name,
                                FullPath = file.FullName,
                                Extension = file.Extension,
                                Size = file.Length,
                                Deleted = DateTime.Now
                            };

                            var fileDb = autoMapper.Mapper.Map<DeletedFile>(deletedFile);

                            //deleting file
                            file.Delete();

                            //save info of the file to db
                            unitOfWork.DeletedFileRepository.Create(fileDb);
                        }
                        catch (Exception ex) { }

                        App.Current.Dispatcher?.BeginInvoke(new Action(() =>
                        {
                            cleanMemoryUC.CleanMemoryPB.Value++;
                            cleanMemoryUC.ProgressLbl.Content = file.Name;
                        }));
                    }
                }
                catch(Exception ex) { }

                App.Current.Dispatcher?.BeginInvoke(new Action(() =>
                {
                    cleanMemoryUC.ProgressLbl.Content = "Completed!";
                }));
            }).Wait();
        }

        private void CleanCookies()
        {
            Task.Run(() =>
            {
                try
                {
                    //closing browsers processes
                    var chromeProc = Process.GetProcessesByName("chrome");
                    var operaProc = Process.GetProcessesByName("opera");

                    foreach(var proc in chromeProc)
                    {
                        proc.Kill();
                    }

                    foreach (var proc in operaProc)
                    {
                        proc.Kill();
                    }

                    foreach (var file in cookies)
                    {
                        if (file.Length != 0)
                        {
                            try
                            {
                                string browser = "";

                                if (file.FullName.Contains("Chrome"))
                                    browser = "Chrome";
                                else if (file.FullName.Contains("Opera"))
                                    browser = "Opera";

                                ClearedCookieFileViewModel clearedCookieFile = new ClearedCookieFileViewModel()
                                {
                                    FileName = file.Name,
                                    FullPath = file.FullName,
                                    BrowserName = browser,
                                    Cleared = DateTime.Now
                                };

                                var fileDb = autoMapper.Mapper.Map<ClearedCookieFile>(clearedCookieFile);

                                //clearing cookie file
                                File.WriteAllText(file.FullName, string.Empty);

                                //save info of the file to db
                                unitOfWork.ClearedCookieFileRepository.CreateAsync(fileDb).Wait();
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
                catch (Exception ex) { }

                App.Current.Dispatcher?.BeginInvoke(new Action(() =>
                {
                    cleanMemoryUC.ProgressLbl.Content = "Completed!";
                }));
                RefreshCleanUC?.Invoke(false);
            });
        }
    }
}
