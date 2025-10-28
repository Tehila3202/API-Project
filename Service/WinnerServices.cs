using chineseAction.Models;
using chineseAction.Repository;
using chineseAction.Services.Logger;
using System.Numerics;
using System.Threading.Tasks;

namespace chineseAction.Service
{
    public class WinnerServices : IWinnerServices
    {

        private readonly IWinnerRepository _WinnerRepository;
        private readonly ICustomerPresentRepository _CustomerPresentRepository;
        private readonly ILoggerService _Logger;
        private readonly IPresentRepository _PresentRepository;

        public WinnerServices(IWinnerRepository WinnerRepository , ICustomerPresentRepository customerPresentRepository, ILoggerService logger, IPresentRepository PresentRepository)
        {
            _Logger = logger;
            _WinnerRepository = WinnerRepository;
            _CustomerPresentRepository = customerPresentRepository;
            _PresentRepository = PresentRepository;
        }

        public IEnumerable<WinnerMask> GetAllWinner()
        {
            try {            
                return  _WinnerRepository.GetAllWinner();}
            catch(Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function GetAllWinner in the file WinnerServices ", "logs.txt");
                return null;

            }
        }

        public WinnerMask getById(int id)
        {
            try { 
                var w = _WinnerRepository.GetAllWinner();
                foreach (var i in w)
                {
                    if (i.Id == id)
                        return i;
                }
                return null;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getById in the file WinnerServices ", "logs.txt");
                return null;

            }
        }


        public bool Create(int presentId)
        {
            try { 
                Present p= _PresentRepository.getById(presentId);
                List<Customer> customer = _CustomerPresentRepository.CustomerForPresent(presentId).ToList();
                Random r = new Random();
                int i=0;
                while(i == 0) { 
                 i = r.Next(customer.Count());
                }
                if (i == 0)
                    return false;
                Winner w = new Winner();            
                w.CustomerId = customer[i].Id;
                //w.Present = customer[i].Name;
                w.PresentId = presentId;
                int? revenues = customer.Count() * p.Price;
                _Logger.Log($"The winner of the gift {presentId} is: Id {customer[i].Id} , Name { customer[i].Name}", "winner.txt");
                _Logger.Log($"The revenues of gift {presentId} is:{revenues} ", "revenues.txt");
                return _WinnerRepository.Create(w);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function Create in the file WinnerServices ", "logs.txt");
                return false;

            }
        }
    }
}
