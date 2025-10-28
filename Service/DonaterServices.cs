using chineseAction.Models;
using chineseAction.Repository;
using chineseAction.Services.Logger;
using Microsoft.Extensions.Logging;
using System.Numerics;
using System.Threading.Tasks;

namespace chineseAction.Service
{
    public class DonaterServices : IDonaterServices
    {

        private readonly IDonaterRepository _DonaterRepository;
        private readonly IPresentRepository _PresentRepository;
        private readonly ILoggerService _Logger;

        public DonaterServices(IDonaterRepository donaterServicesRepository, IPresentRepository PresentRepository, ILoggerService logger)
        {
            _DonaterRepository = donaterServicesRepository;
            _PresentRepository = PresentRepository;
            _Logger = logger;
        }

        public List<Donater> GetAllDonatert()
        {
            try { 
                return _DonaterRepository.GetAllDonater();
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function GetAllDonatert in the file DonaterServices ", "logs.txt");
                return null;

            }
        }

        public IEnumerable<Donater> CreateDonater(Donater Donater)
        {
            try { 
                return _DonaterRepository.CreateDonater(Donater);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function CreateDonater in the file DonaterServices ", "logs.txt");
                return null;

            }
        }


        public void update(Donater donater)
        {
            try { 
            Donater newDonater = new Donater();
            newDonater.Id = donater.Id;
            newDonater.Name = donater.Name;
            newDonater.Phone = donater.Phone;
            newDonater.Mail = donater.Mail;
            _DonaterRepository.updateDonater(newDonater);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function update in the file DonaterServices ", "logs.txt");

            }
        }

        public void deleteDonater(int id)
        {
            try { 
                _DonaterRepository.DeleteDonater(id);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function deleteDonater in the file DonaterServices ", "logs.txt");

            }
        }

        public Donater byPresentId(int id)
        {
            //PresentMask p = _PresentRepository.getById(id);
            
            //if (p != null)
            //{
            //    Donater d = _DonaterRepository.getById((int)p.DonaterId);
            //    return d;
            //}

            return new Donater();

        }

        public Donater getById(int id)
        {
            try { 
            return _DonaterRepository.getById(id);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getById in the file DonaterServices ", "logs.txt");
                return null;

            }
        }


        public List<Donater> getByMail(string mail)
        {
            try { 
            var d = _DonaterRepository.getByMail(mail);
            return d;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getByMail in the file DonaterServices ", "logs.txt");
                return null;

            }
        }

        public List<Donater> getByName(string name)
        {
            try { 
            var d = _DonaterRepository.getByName(name);
            return d;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getByName in the file DonaterServices ", "logs.txt");
                return null;

            }
        }

    }
}
