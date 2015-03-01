using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumChores.Model.Entities;

namespace ScrumChores.Model.Interfaces
{
    public interface IStoryRepository
    {
        Story CreateStory(Story newStory);

        IQueryable<Story> GetStoriesForUser(User thisUser);

        Story GetStory(Guid Id);
    }
}