using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project01_ApiDemo.ApiDtos.CustomerDtos;
using NetCoreAI.Project01_ApiDemo.Context;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var customerlist = _context.Customers.ToList();
            var dtos = _mapper.Map<List<ResultCustomerDto>>(customerlist);
            return Ok(dtos);
        }
        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var entity = _mapper.Map<Customer>(createCustomerDto);
            _context.Customers.Add(entity);
            _context.SaveChanges();
            return Ok("Müşteri Ekleme İşlemi Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Müşteri Silme İşlemi Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var entity = _context.Customers.Find(id);
            var dto = _mapper.Map<GetByIdCustomerDto>(entity);
            return Ok(dto);
        }
        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var entity = _mapper.Map<Customer>(updateCustomerDto);
            _context.Customers.Update(entity);
            _context.SaveChanges();
            return Ok("Müşteri Güncelleme İşlemi Başarılı");

        }
    }
}
