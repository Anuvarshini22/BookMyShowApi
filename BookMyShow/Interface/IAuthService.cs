using BookMyShow.Models;

namespace BookMyShow.Interface
{
    public interface IAuthService
    {
        public List<Customer> GetCustomers();
        public Customer GetById(int id);
        public Customer RegisterCustomer(Customer customer);
        public Admin RegisterAdmin(Admin admin);
        public bool CheckCustomer(Login login);
        public bool CheckAdmin(Login login);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int id);
    }
}
