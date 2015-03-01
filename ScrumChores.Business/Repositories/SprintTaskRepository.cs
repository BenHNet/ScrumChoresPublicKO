using ScrumChores.Business.Context;
using ScrumChores.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumChores.Business.Repositories
{
    public class SprintTaskRepository : ISprintTaskRepository
    {
        private ScrumChoresDbContext _context = new ScrumChoresDbContext();

        public Model.Entities.SprintTask CreateSprintTask(Model.Entities.SprintTask newSprintTask)
        {
            var result = _context.Tasks.Add(newSprintTask);

            _context.SaveChangesAsync();

            return result;
        }

        public List<Model.Entities.SprintTask> GetSprintTasksForStory(Guid storyId)
        {
            var result = _context.Tasks.Where(x => x.Story.StoryID == storyId).ToList();

            return result;
        }

        public Model.Entities.SprintTask GetSprintTask(Guid Id)
        {
            var result = _context.Tasks.Where(x => x.TaskID == Id).FirstOrDefault();

            return result;
        }
    }
}
