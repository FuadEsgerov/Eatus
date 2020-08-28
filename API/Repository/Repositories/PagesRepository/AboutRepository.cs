using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.PagesRepository
{

    public interface IAboutRepository
    {
        IEnumerable<About> GetAbouts();

    }
    public class AboutRepository : IAboutRepository
    {
        private readonly AppDbContext _context;

        public AboutRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<About> GetAbouts()
        {
            return _context.Abouts.ToList();
        }
    }
}
