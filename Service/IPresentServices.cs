using chineseAction.Models;
using System.Threading.Tasks;

namespace chineseAction.Service
{
    public interface IPresentServices
    {
        //public List<TasksWithUsers> GetAllTasksWithUser();
         IEnumerable<PresentMask> GetAllPresent();

         IEnumerable<PresentMask> CreatePresent(PresentMask present);

         void updatePresent(PresentMask present);
        IEnumerable<PresentMask> DeletePresentById(int id);

        void DeleteManyPresent(List<int> list);
        Present getById(int id);
        IEnumerable<PresentMask> getByDonaterId(int DonaterId);
        List<Present> getByName(string Title);
        List<Present> getByNumBuyers(int NumBuyers);

        PresentMask expensive( );

         IEnumerable<PresentMask> category();
         IEnumerable<PresentMask> getByPrice();
        PresentMask popular();
        //public void DeletePresent(Present task);
    }
}
