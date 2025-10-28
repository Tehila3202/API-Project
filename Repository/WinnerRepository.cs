using chineseAction.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace chineseAction.Repository
{
    public class WinnerRepository : IWinnerRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        public WinnerRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public IEnumerable<WinnerMask> GetAllWinner()
        {
            var win = from w in _projectDbContext.Winner
                          join c in _projectDbContext.Customer on w.CustomerId equals c.Id
                          join p in _projectDbContext.Present on w.PresentId equals p.Id
                          select new WinnerMask
                          {
                              Id = w.Id,
                              Present=p.Title,
                              PresentId=p.Id,
                              Customer=c.Name,
                              Mail=c.Mail

                          };
            if (win != null)
                return win.ToList();
            return null;
        }


        //public Winner getById(int id)
        //{
        //    Winner? thisPresent = _projectDbContext.Winner.Find(id);
        //    return (thisPresent);

        //}

        public bool Create(Winner w)
        {
            if (w != null) { 
                _projectDbContext.Winner.Add(w);
                _projectDbContext.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
 
