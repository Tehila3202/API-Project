using chineseAction.Models;

namespace chineseAction.Service
{
    public interface ICustomerPresentServices
    {
        IEnumerable<PresentMask> Cart(int customerId);
        IEnumerable<CustomerPresent> Create(int presentId, int customerId);
        IEnumerable<Customer> CustomerForPresent(int presentId);
        IEnumerable<CustomerPresent> deletePresent(int presentId, int customerId);
        void update( int customerId);
    }
}