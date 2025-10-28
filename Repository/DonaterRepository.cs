using chineseAction.Models;
using chineseAction.Services.Logger;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace chineseAction.Repository
{
    public class DonaterRepository : IDonaterRepository
    {
        private readonly ProjectDbContext _projectDbContext;
        private readonly ILoggerService _Logger;

        public DonaterRepository(ProjectDbContext projectDbContext, ILoggerService LoggerService)
        {
            _projectDbContext = projectDbContext;
            _Logger = LoggerService;
        }

        public List<Donater> GetAllDonater()
        {
            return _projectDbContext.Donater.ToList();
        }

        public IEnumerable<Donater> CreateDonater(Donater Donater)
        {
            _projectDbContext.Donater.Add(Donater);
            _projectDbContext.SaveChanges();
            return GetAllDonater();
        }

        public void DeleteDonater(int id)
        {    
                Donater? thisDonater = _projectDbContext.Donater.Find(id);
                if (thisDonater != null) {
                    _projectDbContext.Donater.Remove(thisDonater);
                    _projectDbContext.SaveChanges();
                }
        }

        public void updateDonater(Donater newDonater)
        {
            //Donater? thisDonater = _projectDbContext.Donater.Find(Id);
            //if (newDonater.Name != null)
            //    thisDonater.Name = newDonater.Name;

            //if (newDonater.Phone != null)
            //    thisDonater.Phone = newDonater.Phone;

            //if (newDonater.Mail != null)
            //    thisDonater.Mail = newDonater.Mail;
            _projectDbContext.Donater.Update(newDonater);
            _projectDbContext.SaveChanges();
        }


        public Donater getById(int id)
        {
            Donater? thisPresent = _projectDbContext.Donater.Find(id);
            return (thisPresent);

        }


        public List<Donater> getByName(string name)
        {
            List<Donater>? list = _projectDbContext.Donater.Where(x => x.Name == name).ToList();
            return (list);

        }

        public List<Donater> getByMail(string mail)
        {
            List<Donater>? list = _projectDbContext.Donater.Where(x => x.Mail == mail).ToList();
            return (list);

        }

    
    }
}
 
