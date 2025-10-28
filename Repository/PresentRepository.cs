using chineseAction.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace chineseAction.Repository
{
    public class PresentRepository : IPresentRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        public PresentRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }


        public IEnumerable<PresentMask> GetAllPresent()
        {
            var present = from p in _projectDbContext.Present
                          join c in _projectDbContext.Category on p.CategoryId equals c.Id
                          join d in _projectDbContext.Donater on p.DonaterId equals d.Id
                          select new PresentMask
                          {
                              Id = p.Id,
                              Title = p.Title,
                              Description = p.Description,
                              Category = c.Name,
                              Price = p.Price,
                              Image = p.Image,
                              Donater = d.Name,
                              NumBuyers = p.NumBuyers
                          };
            if (present != null)
                return present.ToList();
            return null;
        }


        public IEnumerable<PresentMask> CreatePresent(PresentMask present)
        {
            if (present != null)
            {
                if (present.Donater != "" && present.Category != "")
                {

                    Donater? donater = _projectDbContext.Donater.First(x => x.Name == present.Donater);
                    Category? category = _projectDbContext.Category.First(x => x.Name == present.Category);
                    if (donater != null && category != null)
                    {
                        Present p = new Present();
                        p.Id = present.Id;
                        p.Title = present.Title;
                        p.Description = present.Description;
                        p.CategoryId = category.Id;
                        p.Price = present.Price;
                        p.Image = present.Image;
                        p.DonaterId = donater.Id;
                        p.NumBuyers = present.NumBuyers;
                        _projectDbContext.Present.Add(p);
                        _projectDbContext.SaveChanges();
                    }
                }
            }
            return GetAllPresent();
        }



        public IEnumerable<PresentMask> DeletePresentById(int id)
        {
            if (id != null)
            {
                Present? thisTask = _projectDbContext.Present.Find(id);
                if (thisTask != null)
                {
                    _projectDbContext.Present.Remove(thisTask);
                    _projectDbContext.SaveChanges();
                }
            }
            return GetAllPresent();
        }

        public Present getById(int id)
        {
            Present? thisPresent = _projectDbContext.Present.Find(id);
            _projectDbContext.SaveChanges();
            return (thisPresent);

        }

        public IEnumerable<PresentMask> getByDonaterId(int DonaterId)
        {
                var present = from p in _projectDbContext.Present.Where(x => x.DonaterId == DonaterId)
                              join c in _projectDbContext.Category on p.CategoryId equals c.Id
                              join d in _projectDbContext.Donater on p.DonaterId equals d.Id
                              select new PresentMask
                              {
                                  Id = p.Id,
                                  Title = p.Title,
                                  Description = p.Description,
                                  Category = c.Name,
                                  Price = p.Price,
                                  Image = p.Image,
                                  Donater = d.Name,
                                  NumBuyers = p.NumBuyers
                              };
                if (present != null)
                {
                    _projectDbContext.SaveChanges();
                    return (present);
                }
            return null;
        }

        public List<Present> getByNumBuyers(int NumBuyers)
        {
            List<Present>? list = _projectDbContext.Present.Where(x=>x.NumBuyers==NumBuyers).ToList();
            _projectDbContext.SaveChanges();
            return (list);

        }

        public List<Present> getByName(string Title)
        {
            List<Present>? list = _projectDbContext.Present.Where(x => x.Title == Title).ToList();
            _projectDbContext.SaveChanges();
            return (list);

        }

        public void updatePresent( Present newPresent)
        {
            //Present? thisPresent = _projectDbContext.Present.Find(Id);
            //if (newPresent.Title != null)
            //    thisPresent.Title = newPresent.Title;

            //if (newPresent.Description != null)
            //    thisPresent.Description = newPresent.Description;

            ////if (newPresent.CategoryId != null)
            ////    thisPresent.CategoryId = newPresent.CategoryId;

            //if (newPresent.Image != null)
            //    thisPresent.Image = newPresent.Image;
            //if (newPresent.Price != null)
            //    thisPresent.Price = newPresent.Price;

            ////if (newPresent.DonaterId != null)
            ////    thisPresent.DonaterId = newPresent.DonaterId;

            //if (newPresent.NumBuyers != null)
            //    thisPresent.NumBuyers = newPresent.NumBuyers;
            _projectDbContext.Present.Update(newPresent);
            _projectDbContext.SaveChanges();
        }
        //public List<Present> GetTasks()
        //{
        //    var Present = _projectDbContext.Tasks.FromSqlRaw("EXEC Tasks_GetAll").ToList();
        //    return Present;
        //}
        //public List<TasksWithUsers> GetAllTasksWithUsers()
        //{
        //    var tasksWithUsers = _projectDbContext.Tasks  //tasks table
        //                   .GroupJoin(
        //                   _projectDbContext.Users,  //users table
        //                   task => task.UserId,//fk
        //                   user => user.UserId,//pk
        //                   (task, users) => new
        //                   {
        //                       Task = task,
        //                       User = users.FirstOrDefault() // Take the first user if it exists, otherwise null
        //                   })
        //                   .Select(joinResult => new TasksWithUsers
        //                   {
        //                       TaskId = joinResult.Task.TaskId,
        //                       Title = joinResult.Task.Title,
        //                       Description = joinResult.Task.Description,
        //                       UserFirstName = joinResult.User.FirstName,
        //                       UserLastName = joinResult.User.LastName
        //                   })
        //    .ToList();
        //    var taskTitlesList2 = new List<Present> { new Present() { Title = "test", TaskId = 3 } };
        //    var distinctTitles = _tasksDbContext.Tasks.Distinct(); //return non dulicate valuews
        //    var unionTitles = _tasksDbContext.Tasks.Union(taskTitlesList2);
        //    return tasksWithUsers;
        //}


    }
}

