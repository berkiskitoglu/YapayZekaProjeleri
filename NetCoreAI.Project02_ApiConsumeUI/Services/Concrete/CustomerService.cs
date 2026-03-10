using AutoMapper;
using NetCoreAI.Project02_ApiConsumeUI.Dtos.CustomerDtos;
using NetCoreAI.Project02_ApiConsumeUI.Services.Abstract;
using NetCoreAI.Project02_ApiConsumeUI.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace NetCoreAI.Project02_ApiConsumeUI.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public CustomerService(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _client = clientFactory.CreateClient("CustomerApi");
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CreateCustomerViewModel createCustomerViewModel)
        {
            var dto = _mapper.Map<CreateCustomerDto>(createCustomerViewModel);
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync("Customers", stringContent);
            if (!responseMessage.IsSuccessStatusCode)
            {
                var error = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"API Hatası: {responseMessage.StatusCode} - {error}");
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _client.DeleteAsync($"Customers/{id}");
        }

        public async Task<List<ResultCustomerViewModel>> GetAllCustomersAsync()
        {
            var response = await _client.GetAsync("Customers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var dtos = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
                return _mapper.Map<List<ResultCustomerViewModel>>(dtos);
            }
            return new List<ResultCustomerViewModel>();
        }

        public async Task<UpdateCustomerViewModel> GetByIdCustomerAsync(int id)
        {
            var response = await _client.GetAsync($"Customers/{id}");
            var jsonData = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<GetByIdCustomerDto>(jsonData);
            return _mapper.Map<UpdateCustomerViewModel>(dto);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerViewModel updateCustomerViewModel)
        {
            var dto = _mapper.Map<UpdateCustomerDto>(updateCustomerViewModel);
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await _client.PutAsync("Customers", stringContent);
        }
    }
}