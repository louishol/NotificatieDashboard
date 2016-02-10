using AutoMapper;
using Lib.DAL;
using Lib.Models;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Helpers
{
    public class AutoMapperConfig
    {

        public static void Initialize()
        {
            Mapper.CreateMap<tblApplications, Application>();
            Mapper.CreateMap<tblDevices, Device>();
            Mapper.CreateMap<tblMessages, Message>();
            Mapper.CreateMap<tblOperatingSystems, Lib.Models.OperatingSystem>();
            Mapper.CreateMap<tblCustomers, Customer>();
            Mapper.CreateMap<Customer, tblCustomers>();
            Mapper.CreateMap<tblPhases, Phase>();
            Mapper.CreateMap<tblLanguageCodes, LanguageCode>();
            Mapper.CreateMap<tblCrashReports, CrashReport>();
            Mapper.CreateMap<MessageViewModel, tblMessages>();
            Mapper.CreateMap<tblMessages, MessageViewModel>();
            Mapper.CreateMap<tblCounts, Counter>();
            Mapper.CreateMap<ApplicationCreateViewModel, Application>();
            Mapper.CreateMap<Application, tblApplications>();
            Mapper.CreateMap<Lib.Models.OperatingSystem, tblOperatingSystems>();
            Mapper.CreateMap<Phase, tblPhases>();
            Mapper.CreateMap<Application, ApplicationSetViewModel>();
        }
    }
}
