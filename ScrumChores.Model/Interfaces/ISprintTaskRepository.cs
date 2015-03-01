using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumChores.Model.Entities;

namespace ScrumChores.Model.Interfaces
{
    public interface ISprintTaskRepository
    {
        SprintTask CreateSprintTask(SprintTask newSprintTask);

        List<SprintTask> GetSprintTasksForStory(Guid storyId);

        SprintTask GetSprintTask(Guid Id);
    }
}