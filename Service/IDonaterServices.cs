using chineseAction.Models;

namespace chineseAction.Service
{
    public interface IDonaterServices
    {
        IEnumerable<Donater> CreateDonater(Donater Donater);
        void deleteDonater(int id);
        List<Donater> GetAllDonatert();
        void update(Donater donater);
        Donater byPresentId(int id);
        Donater getById(int id);
        List<Donater> getByName(string name);
        List<Donater> getByMail(string mail);
    }
}