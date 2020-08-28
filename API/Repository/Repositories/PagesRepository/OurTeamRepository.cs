using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.PagesRepository
{
    public interface IOurTeamRepository
    {
        IEnumerable<OurTeam> GetOurTeams();

    }
    public class OurTeamRepository : IOurTeamRepository
    {
        private readonly AppDbContext _context;

        public OurTeamRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<OurTeam> GetOurTeams()
        {
            return _context.OurTeams.ToList();
        }
    }
}
