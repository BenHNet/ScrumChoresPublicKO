using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScrumChores.Business.Repositories;
using ScrumChores.Model.Entities;
using ScrumChores.Model.Interfaces;
using ScrumChoresPublicKO.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace ScrumChoresPublicKO.API
{
    public class SprintController : ApiController
    {

        private ISprintRepository _sprintRepo;
        private IUserRepository _userRepo;
        private UserManager<ApplicationUser> _userManager;

        public SprintController()
            : this(new SprintRepository(), new UserRepository(), new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public SprintController(ISprintRepository repoSprint, IUserRepository repoUser, UserManager<ApplicationUser> userManager)
        {
            _sprintRepo = repoSprint;
            _userRepo = repoUser;
            _userManager = userManager;
        }

        // GET api/<controller>
        public IEnumerable<Sprint> Get()
        {
            try
            {
                var user = _userRepo.GetUser(_userManager.FindById(this.User.Identity.GetUserId()).UserID);

                var result = _sprintRepo.GetSprintsForUser(user.Result).ToList();
                result.Insert(0, new Sprint() { SprintName = "Backlog" });

                return result.AsQueryable();
            }
            catch
            {
                var result = _sprintRepo.GetSprints().ToList();
                result.Insert(0, new Sprint() { SprintName = "Backlog" });

                return result.AsQueryable();
            }
        }

        // GET api/<controller>/5
        public Sprint Get(int id)
        {
            return new Sprint();
        }

        // POST api/<controller>
        public void Post([FromBody]Sprint value)
        {
            _sprintRepo.CreateSprint(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Sprint value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}