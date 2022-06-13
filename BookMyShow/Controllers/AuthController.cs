using BookMyShow.Interface;
using BookMyShow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _customerService;
        public AuthController(IAuthService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("all")]
        public List<Customer> GetCustomers()
        {
            return _customerService.GetCustomers();
        }
        [HttpGet("{id}")]
        public Customer GetById(int id)
        {
            return _customerService.GetById(id);
        }
        [HttpPost("registerCustomer")]
        public Customer RegisterNewCustomer(Customer customer)
        {
            return _customerService.RegisterCustomer(customer);
        }
        [HttpPost("registerAdmin")]
        public Admin RegisterNewAdmin(Admin admin)
        {
            return _customerService.RegisterAdmin(admin);
        }
        [HttpPost("loginCustomer")]
        public bool LoginCustomer(Login login)
        {
            return _customerService.CheckCustomer(login);
        }

        [HttpPost("loginAdmin")]
        public bool LoginAdmin(Login login)
        {
            return _customerService.CheckAdmin(login);
        }

        [HttpPut]
        public bool UpdateCustomer(Customer customer)
        {
            return _customerService.UpdateCustomer(customer);
        }
        [HttpDelete("{id}")]
        public bool DeleteCustomer(int id)
        {
            return _customerService.DeleteCustomer(id);

        }
    }
}
