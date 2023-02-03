using DemoApplication.Core.Domain.ResponseModel;
using DemoApplication.Infra.Domain.Entities;
using DemoApplication.Shared;
using AutoMapper;

namespace APIDemo.Configurations
{
    public class AutoMapperProfiler: Profile
    {
        public AutoMapperProfiler() 
        {
            CreateMap<PagedList<Result>, PagedList<ResultResponseModel>>();
            CreateMap<Result, ResultResponseModel>();
        }
    }
}
