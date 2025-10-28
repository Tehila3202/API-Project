using chineseAction.Models;

namespace chineseAction.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        string Register(Customer customer);
    }
}