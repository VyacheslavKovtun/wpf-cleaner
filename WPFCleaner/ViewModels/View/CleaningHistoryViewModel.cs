using DBLibrary.Models.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCleaner.Models;
using WPFCleaner.UserControls;
using WPFCleaner.ViewModels.Models;

namespace WPFCleaner.ViewModels.View
{
    public class CleaningHistoryViewModel
    {
        UnitOfWork unitOfWork;
        AutoMapperBase autoMapper;

        public ObservableCollection<DeletedFileViewModel> TmpFiles { get; set; } = new ObservableCollection<DeletedFileViewModel>();
        public ObservableCollection<ClearedCookieFileViewModel> Cookies { get; set; } = new ObservableCollection<ClearedCookieFileViewModel>();

        public CleaningHistoryViewModel() 
        {
            unitOfWork = UnitOfWork.Instance;
            autoMapper = AutoMapperBase.Instance;

            LoadDBData();
        }

        private void LoadDBData()
        {
            //getting temp files from db
            var dbTmpFiles = unitOfWork.DeletedFileRepository.GetAllAsync().Result.ToList();

            TmpFiles = autoMapper.Mapper
                .Map<ObservableCollection<DeletedFileViewModel>>(dbTmpFiles);

            //getting cookies from db
            var dbCookies = unitOfWork.ClearedCookieFileRepository.GetAllAsync().Result.ToList();

            Cookies = autoMapper.Mapper
                .Map<ObservableCollection<ClearedCookieFileViewModel>>(dbCookies);
        }
    }
}
