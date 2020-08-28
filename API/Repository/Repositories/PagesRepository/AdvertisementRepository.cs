using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.PagesRepository
{

    public interface IAdvertisementRepository
    {
        IEnumerable<Advertisement> GetAdvertisements();

    }
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly AppDbContext _context;

        public AdvertisementRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return _context.Advertisements.ToList();
        }
    }
}
