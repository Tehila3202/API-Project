using chineseAction.Models;

namespace chineseAction.Repository
{
    public interface ICustomerPresentRepository
    {
        IEnumerable<PresentMask> Cart(int customerId);
        IEnumerable<Customer> CustomerForPresent(int presentId);
        IEnumerable<CustomerPresent> deletePresent(CustomerPresent cp);

        IEnumerable<CustomerPresent> Create(CustomerPresent cp);
       void Update(CustomerPresent cp);

    }
}