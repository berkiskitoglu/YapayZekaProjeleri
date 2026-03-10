using NetCoreAI.Project02_ApiConsumeUI.ViewModels;

namespace NetCoreAI.Project02_ApiConsumeUI.Services.Abstract
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerViewModel>> GetAllCustomersAsync();
        Task<UpdateCustomerViewModel> GetByIdCustomerAsync(int id);
        Task CreateCustomerAsync(CreateCustomerViewModel createCustomerViewModel);
        Task UpdateCustomerAsync(UpdateCustomerViewModel updateCustomerViewModel);
        Task DeleteCustomerAsync(int id);
    }
}
