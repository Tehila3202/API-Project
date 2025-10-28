using chineseAction.Models;
using chineseAction.Repository;
using chineseAction.Services.Logger;
using System.Numerics;
using System.Threading.Tasks;

namespace chineseAction.Service
{
    public class CustomerServices : ICustomerServices
    {

        private readonly ICustomerRepository _CustomerRepository;
        private readonly ILoggerService _Logger;

        public CustomerServices(ICustomerRepository CustomerRepository , ProjectDbContext projectDbContext, ILoggerService logger)
        {
            _CustomerRepository = CustomerRepository;
            _Logger = logger;
        }

        public string Register(Customer customer)
        {
            try { 
                var c = _CustomerRepository.GetAllCustomer();
                bool Customer = c.Exists(x => x.UserName == customer.UserName || x.Mail == customer.Mail);
                if (Customer==false) 
                  return  _CustomerRepository.Register(customer);
                return "somthing went worn, try register again";
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function Register in the file CustomerServices ", "logs.txt");
                return null;

            }
        }

    }
}
