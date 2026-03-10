using AutoMapper;
using NetCoreAI.Project01_ApiDemo.ApiDtos.CustomerDtos;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
                CreateMap<Customer, ResultCustomerDto>();
                CreateMap<Customer, GetByIdCustomerDto>();
                CreateMap<CreateCustomerDto,Customer>();
                CreateMap<UpdateCustomerDto,Customer>();
        }
    }
}
