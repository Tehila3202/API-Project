using chineseAction.Models;
using System.Linq;

namespace chineseAction.Repository
{
    public class CustomerPresentRepository : ICustomerPresentRepository
    {

        private readonly ProjectDbContext _projectDbContext;

        public CustomerPresentRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public IEnumerable<PresentMask> Cart(int customerId)
        {
            var present = from cp in _projectDbContext.CustomerPresent.Where(x => x.CustomerId == customerId && x.Status == false)
                          join p in _projectDbContext.Present on cp.PresentId equals p.Id 
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
        
        
        public IEnumerable<Customer> CustomerForPresent(int presentId)
        {
            var customer = from cp in _projectDbContext.CustomerPresent.Where(x => x.PresentId == presentId && x.Status == true)
                          join c in _projectDbContext.Customer on cp.CustomerId equals c.Id                    
                          select new Customer
                          {
                              Id = c.Id,
                              Name = c.Name,
                              UserName = c.UserName,                           
                              Password = c.Password,
                              Adress = c.Adress,
                              Phone = c.Phone,
                              Mail = c.Mail
                          };
            if (customer != null)
            {
                _projectDbContext.SaveChanges();
                return (customer);
            }
            return null;

        }

        public IEnumerable<CustomerPresent> deletePresent(CustomerPresent cp)
        {
            if (cp != null)
            {
                _projectDbContext.CustomerPresent.Remove(cp);
                _projectDbContext.SaveChanges();
            }
            return _projectDbContext.CustomerPresent.ToList();
        }


        public IEnumerable<CustomerPresent> Create(CustomerPresent CustomerPresent)
        {
            _projectDbContext.CustomerPresent.Add(CustomerPresent);
            _projectDbContext.SaveChanges();
            return _projectDbContext.CustomerPresent.ToList();
        }

        public void Update(CustomerPresent CustomerPresent)
        {
            _projectDbContext.CustomerPresent.Update(CustomerPresent);
            _projectDbContext.SaveChanges();
             _projectDbContext.CustomerPresent.ToList();
        }



            //var list = from p in _projectDbContext.Present
            //           join cp in _projectDbContext.CustomerPresent on p.Id equals cp.PresentId
            //           where cp.Status == true
            //           select new CustomerPresentMask
            //           {
            //               Title = p.Title,
            //               customers = _projectDbContext.CustomerPresent.Where(x => x.PresentId == p.Id && x.Status == true).ToList()
            //           };

            //var customers = list.ToList();
            //    return customers.DistinctBy(x => x.Title);

        }
}
