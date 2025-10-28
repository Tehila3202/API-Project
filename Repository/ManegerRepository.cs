using chineseAction.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace chineseAction.Repository
{
    public class ManegerRepository : IManegerRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        public ManegerRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public List<Maneger> GetAllManeger()
        {
            return _projectDbContext.Maneger.ToList();
        }



    }
}
 
