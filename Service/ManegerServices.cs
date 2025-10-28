using chineseAction.Models;
using chineseAction.Repository;
using chineseAction.Services.Logger;
using System.Numerics;
using System.Threading.Tasks;

namespace chineseAction.Service
{
    public class ManegerServices : IManegerServices
    {
        private readonly IManegerRepository _ManegerRepository;
        private readonly ILoggerService _Logger;

        public ManegerServices(IManegerRepository PresentRepository, ILoggerService logger)
        {

            _ManegerRepository = PresentRepository;
            _Logger = logger;
        }

        public List<Maneger> GetAllManeger()
        {
            try {
                 return _ManegerRepository.GetAllManeger();
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function GetAllManeger in the file ManegerServices ", "logs.txt");
                return null;

            }
        }



    }
}
