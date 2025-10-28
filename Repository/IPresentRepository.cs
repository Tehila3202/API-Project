using chineseAction.Models;
using System.Threading.Tasks;

namespace chineseAction.Repository
{
    public interface IPresentRepository
    {
        IEnumerable<PresentMask> GetAllPresent();

        //List<TasksWithUsers> GetAllTasksWithUsers();
        IEnumerable<PresentMask> CreatePresent(PresentMask Present);

        IEnumerable<PresentMask> DeletePresentById(int id);
        void updatePresent( Present newPresent);

        Present getById(int id);
        IEnumerable<PresentMask> getByDonaterId(int DonaterId);
        List<Present> getByName(string Title);
        List<Present> getByNumBuyers(int NumBuyers);


        //void DeletePresent(Present Present);
    }
}
