using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessModel = BusinessLayer.Models;
using DataModel = DataAccessLayer.Models;


namespace TaskPlannerAPI.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BusinessModel.Medicine, DataModel.Medicine>();
            CreateMap<DataModel.Medicine, BusinessModel.Medicine>();
            CreateMap<ViewModel.Medicine, BusinessModel.Medicine>();
            CreateMap<BusinessModel.Medicine, ViewModel.Medicine>();
        }
    }
}
