using chineseAction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace chineseAction.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProjectDbContext _projectDbContext;
        private readonly PasswordHasher<Customer> _passwordHasher;

        public CustomerRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
            _passwordHasher = new PasswordHasher<Customer>();
        }

        public List<Customer> GetAllCustomer()
        {
            return _projectDbContext.Customer.ToList();
        }

        public string Register(Customer customer)
        {
            try
            {
                customer.Password = _passwordHasher.HashPassword(customer, customer.Password);

                _projectDbContext.Customer.Add(customer);
                _projectDbContext.SaveChanges();
                return "user register seccsfuly";

                throw new KeyNotFoundException("somthing went worn, try register again");
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }

        }
    }
}
