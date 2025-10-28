using chineseAction.Models;
using chineseAction.Repository;
using chineseAction.Services.Logger;
using Microsoft.Extensions.Logging;
using System.Numerics;
using System.Threading.Tasks;

namespace chineseAction.Service
{
    public class CustomerPresentServices : ICustomerPresentServices
    {
        private readonly ICustomerPresentRepository _CustomerPresentRepository;
        private readonly ProjectDbContext _projectDbContext;
        private readonly ILoggerService _Logger;

        public CustomerPresentServices(ICustomerPresentRepository CustomerPresentRepository, ProjectDbContext projectDbContext, ILoggerService logger)
        {
            _CustomerPresentRepository = CustomerPresentRepository;
            _projectDbContext = projectDbContext;
            _Logger = logger;
        }

        public IEnumerable<PresentMask> Cart(int customerId)
        {
            try { 
                return _CustomerPresentRepository.Cart(customerId);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function Cart in the file CustomerPresentServices ", "logs.txt");
                return null;

            }
        }

        public IEnumerable<Customer> CustomerForPresent(int presentId)
        {
            try {
                return _CustomerPresentRepository.CustomerForPresent(presentId);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function CustomerForPresent in the file CustomerPresentServices ", "logs.txt");
                return null;

            }
        }

        public IEnumerable<CustomerPresent> deletePresent(int presentId, int customerId)
        {
            try { 
                CustomerPresent? cp = _projectDbContext.CustomerPresent.First(x => x.CustomerId == customerId && x.PresentId == presentId && x.Status == false);
                return _CustomerPresentRepository.deletePresent(cp);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function deletePresent in the file CustomerPresentServices ", "logs.txt");
                return null;

            }
        }

        public IEnumerable<CustomerPresent> Create(int presentId, int customerId)
        {
            try { 
                CustomerPresent cp = new CustomerPresent();
                cp.CustomerId = customerId;
                cp.PresentId = presentId;
                cp.Status = false;
                return _CustomerPresentRepository.Create(cp);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function Create in the file CustomerPresentServices ", "logs.txt");
                return null;

            }
        }


        public void update( int customerId)
        {
            try { 
                List<CustomerPresent>? cp = _projectDbContext.CustomerPresent.Where(x => x.CustomerId == customerId && x.Status == false).ToList();

                foreach (var item in cp)
                {
                    item.Status = true;
                    _CustomerPresentRepository.Update(item);
                }
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function update in the file CustomerPresentServices ", "logs.txt");

            }
        }
    }
}

