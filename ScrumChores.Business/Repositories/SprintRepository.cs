using ScrumChores.Business.Context;
using ScrumChores.Model.Entities;
using ScrumChores.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumChores.Business.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        private ScrumChoresDbContext _context = new ScrumChoresDbContext();

        public Sprint CreateSprint(Sprint newSprint)
        {
            var result = _context.Sprints.Add(newSprint);
            
            _context.SaveChangesAsync();

            return result;
        }

        public IQueryable<Sprint> GetSprintsForUser(User thisUser)
        {
            var result =  _context.Sprints.AsQueryable();

            return result;
        }

        public Sprint GetSprint(Guid Id)
        {
            var result = _context.Sprints.Where(x => x.SprintID == Id).FirstOrDefault();

            return result;
        }
    }
}
