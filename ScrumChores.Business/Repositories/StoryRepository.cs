using ScrumChores.Business.Context;
using ScrumChores.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumChores.Business.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private ScrumChoresDbContext _context = new ScrumChoresDbContext();

        public Model.Entities.Story CreateStory(Model.Entities.Story newStory)
        {
            var result = _context.Stories.Add(newStory);

            _context.SaveChangesAsync();

            return result;
        }

        public IQueryable<Model.Entities.Story> GetStoriesForUser(Model.Entities.User thisUser)
        {
            var result = _context.Stories.AsQueryable();

            return result;
        }
        
        public Model.Entities.Story GetStory(Guid Id)
        {
            var result = _context.Stories.Where(x => x.StoryID == Id).FirstOrDefault();

            return result;
        }
    }
}
