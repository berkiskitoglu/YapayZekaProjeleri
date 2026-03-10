using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project02_ApiConsumeUI.Services.Abstract;
using NetCoreAI.Project02_ApiConsumeUI.ViewModels;
using Newtonsoft.Json;

namespace NetCoreAI.Project02_ApiConsumeUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> CustomerList()
        {
            var customerList = await _customerService.GetAllCustomersAsync();
            return View(customerList);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerViewModel createCustomerViewModel)
        {
            await _customerService.CreateCustomerAsync(createCustomerViewModel);
            return RedirectToAction("CustomerList");
        }
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var customerList = await _customerService.GetByIdCustomerAsync(id);
            return View(customerList);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerViewModel updateCustomerViewModel)
        {
            await _customerService.UpdateCustomerAsync(updateCustomerViewModel);
            return RedirectToAction("CustomerList");
        }
    }
}
