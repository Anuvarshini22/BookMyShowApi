using BookMyShow.Interface;
using BookMyShow.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShow.Service
{

    /// <summary>
    /// ///////use asp net code auth for regisyer ad login.....use asp only ..store the pass awortd and login customer table for login/register
    /// </summary>
    public class AuthService:IAuthService
    {
            private IDbConnection _context;

            public AuthService(IConfiguration configuration)
            {
                _context = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
            }
            public List<Customer> GetCustomers()
            {
                var query = "SELECT * FROM Customer";
                return _context.Query<Customer>(query).ToList();
            }
        public Customer GetById(int id)
        {
            var query = "SELECT * FROM Customer where Id=@Id";
            return _context.Query<Customer>(query, new { @Id = id }).Single();
        }
        public Customer RegisterCustomer(Customer customer)
        {
            var getCustomer= _context.QuerySingleOrDefault<Customer>("SELECT * FROM Customer where Name=@Name", new { @Name = customer.Name });
            if(getCustomer!=null)
            {
                return null;
            }
            _context.Execute("INSERT INTO Customer(Name,Email,Password)VALUES(@Name,@Email,@Password)", new { Name = customer.Name, Email = customer.Email, Password = customer.Password });
            return customer;
        }

        public Admin RegisterAdmin(Admin admin)
        {
            var getAdmin = _context.QuerySingleOrDefault<Admin>("SELECT * FROM Admin where Name=@Name", new { @Name = admin.Name });
            if (getAdmin != null)
            {
                return null;
            }
            _context.Execute("INSERT INTO Admin(Name,Email,Password)VALUES(@Name,@Email,@Password)", new { Name = admin.Name, Email = admin.Email, Password = admin.Password });
            return admin;
        }

        public bool CheckCustomer(Login login)
        {
            var findCustomer= _context.QuerySingleOrDefault<Customer>("SELECT * FROM Customer where Email=@Email", new { Email = login.Email });
            if (findCustomer != null)
            {
                return true;
            }
            else
            { 
                return false;
                }
        }

        public bool CheckAdmin(Login login)
        {
            var findAdmin = _context.QuerySingleOrDefault<Admin>("SELECT * FROM Admin where Email=@Email", new { Email = login.Email });
           
            if (findAdmin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            return (_context.Execute("UPDATE Customer SET Name=@Name,Email=@Email,Password=@Password where Id=@Id")) == 1;

        }
        public bool DeleteCustomer(int id)
        {
            return (_context.Execute("DELETE FROM Customer where Id=@id", new { id }) == 1);

        }
    }
}
