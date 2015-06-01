using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumChores.Model.Entities;

namespace ScrumChores.Model.Interfaces
{
    public interface ISprintRepository
    {
        Sprint CreateSprint(Sprint newSprint);

        IQueryable<Sprint> GetSprintsForUser(User thisUser);

        IQueryable<Sprint> GetSprints();

        Sprint GetSprint(Guid Id);
    }
}