using AutoMapper;
using NetCoreAI.Project02_ApiConsumeUI.Dtos.CustomerDtos;
using NetCoreAI.Project02_ApiConsumeUI.ViewModels;

namespace NetCoreAI.Project02_ApiConsumeUI.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<ResultCustomerDto, ResultCustomerViewModel>();
            CreateMap<CreateCustomerViewModel, CreateCustomerDto>();
            CreateMap<UpdateCustomerViewModel, UpdateCustomerDto>();
            CreateMap<GetByIdCustomerDto, GetByIdCustomerViewModel>();
            CreateMap<GetByIdCustomerDto, UpdateCustomerViewModel>();
        }
    }
}
