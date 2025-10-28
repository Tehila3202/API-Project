using chineseAction.Models;

namespace chineseAction.Repository
{
    public interface IDonaterRepository
    {
        IEnumerable<Donater> CreateDonater(Donater Donater);
        void DeleteDonater(int id);
        List<Donater> GetAllDonater();
        void updateDonater( Donater newDonater);

        //Donater byPresentId(int id);
        List<Donater> getByName(string name);
        List<Donater> getByMail(string mail);
        Donater getById(int DonaterId);
    }
}