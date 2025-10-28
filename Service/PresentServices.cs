using chineseAction.Models;
using chineseAction.Repository;
using chineseAction.Services.Logger;
using System.Threading.Tasks;

namespace chineseAction.Service
{
    public class PresentServices : IPresentServices
    {

        private readonly IPresentRepository _PresentRepository;
        private readonly ProjectDbContext _projectDbContext;
        private readonly ILoggerService _Logger;

        //private readonly GenericRepository<Tasks> _tasksRepository;

        public PresentServices(IPresentRepository taskRepository,ProjectDbContext projectDbContext, ILoggerService LoggerService)
        {
            _PresentRepository = taskRepository;
            _projectDbContext = projectDbContext;
            _Logger = LoggerService;
        }
        
        public IEnumerable<PresentMask> GetAllPresent()
        {
            try { 
                return _PresentRepository.GetAllPresent();
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function GetAllPresent in the file PresentServices ", "logs.txt");
                return null;
            }
        }

        public IEnumerable<PresentMask> CreatePresent(PresentMask Present)
        {
            try { 
          //_Logger.Log($"Create Present start:{Present.Title} , Id:{Present.Id}", "logs");
                return _PresentRepository.CreatePresent(Present); 
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function CreatePresent in the file PresentServices ", "logs.txt");
                return null;
            }
        }

        public void updatePresent(PresentMask present)
        {
            try { 
            if (present != null)
            {
                Donater? donater = _projectDbContext.Donater.First(x => x.Name == present.Donater);
                Category? category = _projectDbContext.Category.First(x => x.Name == present.Category);
                Present newPresent = new Present();
                newPresent.Id = present.Id;
                newPresent.Title = present.Title;
                newPresent.Description = present.Description;
                newPresent.CategoryId = category.Id;
                newPresent.Image = present.Image;
                newPresent.Price = present.Price;
                newPresent.DonaterId = donater.Id;
                newPresent.NumBuyers = present.NumBuyers;
                _PresentRepository.updatePresent(newPresent);
            }
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function GetAllPresent in the file PresentServices ", "logs.txt");
            }
        }

        public IEnumerable<PresentMask> DeletePresentById(int id)
        {
            try { 
                return _PresentRepository.DeletePresentById(id);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function DeletePresentById in the file PresentServices ", "logs.txt");
                return null;
            }
        }

        public void DeleteManyPresent(List<int> list)
        {
            try { 
            foreach (var l in list)
            {
                _PresentRepository.DeletePresentById(l);
            }
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function DeleteManyPresent in the file PresentServices ", "logs.txt");
            }
        }

        public Present getById(int id)
        {
            try {
                //var p= _PresentRepository.GetAllPresent();
                //foreach (var i in p)
                //{
                //    if (i.Id == id)
                //        return i;
                //}
                //return null;
                return _PresentRepository.getById(id);
}
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getById in the file PresentServices ", "logs.txt");
                return null;
            }
        }

        public IEnumerable<PresentMask> getByDonaterId(int DonaterId)
        {
            try {
            return _PresentRepository.getByDonaterId(DonaterId);
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getByDonaterId in the file PresentServices ", "logs.txt");
                return null;
            }

        }

        public List<Present> getByNumBuyers(int NumBuyers)
        {
            try { 
            var p=_PresentRepository.getByNumBuyers(NumBuyers);
             return p;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getByNumBuyers in the file PresentServices ", "logs.txt");
                return null;
            }
        }

        public List<Present> getByName(string Title)
        {
            try { 
            var p = _PresentRepository.getByName(Title);
            return p;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getByName in the file PresentServices ", "logs.txt");
                return null;
            }
        }

        public PresentMask expensive()
        {
            try { 
            var p = _PresentRepository.GetAllPresent();
            var present = p.OrderByDescending(x => x.Price).First();
            return present;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function expensive in the file PresentServices ", "logs.txt");
                return null;
            }
        }
        public IEnumerable<PresentMask> category()
        {
            try { 
            var p = _PresentRepository.GetAllPresent();
            var present = p.OrderBy(x => x.Category);
            return present;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function category in the file PresentServices ", "logs.txt");
                return null;
            }
        }
        public IEnumerable<PresentMask> getByPrice()
        {
            try { 
            var p = _PresentRepository.GetAllPresent();
            var present = p.OrderBy(x => x.Price);
            return present;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function getByPrice in the file PresentServices ", "logs.txt");
                return null;
            }
        }


        public PresentMask popular()
        {
            try { 
            var p = _PresentRepository.GetAllPresent();
            var present = p.OrderByDescending(x => x.NumBuyers).First();
            return present;
            }
            catch (Exception e)
            {
                _Logger.Log($"There is an error:{e.Message} the function popular in the file PresentServices ", "logs.txt");
                return null;
            }

        }

    }
}
