using AutoMapper;
using DBLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCleaner.ViewModels.Models;

namespace WPFCleaner.Config
{
    class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DeletedFile, DeletedFileViewModel>();
            CreateMap<DeletedFileViewModel, DeletedFile>();

            CreateMap<ClearedCookieFile, ClearedCookieFileViewModel>();
            CreateMap<ClearedCookieFileViewModel, ClearedCookieFile>();
        }
    }
}
