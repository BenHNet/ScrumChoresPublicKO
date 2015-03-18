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
    public class StoryController : ApiController
    {
        private IStoryRepository _StoryRepo;
        private IUserRepository _userRepo;
        private UserManager<ApplicationUser> _userManager;

        public StoryController()
            : this(new StoryRepository(), new UserRepository(), new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public StoryController(IStoryRepository repoStory, IUserRepository repoUser, UserManager<ApplicationUser> userManager)
        {
            _StoryRepo = repoStory;
            _userRepo = repoUser;
            _userManager = userManager;
        }

        // GET api/<controller>
        public IEnumerable<Story> Get()
        {
            try
            {
                var user = _userRepo.GetUser(_userManager.FindById(this.User.Identity.GetUserId()).UserID);

                var result = _StoryRepo.GetStoriesForUser(user.Result);

                return result;
            }
            catch
            {
                var result = _StoryRepo.GetStories();

                return result;
            }
        }

        // GET api/<controller>/5
        public Story Get(int id)
        {
            return new Story();
        }

        // POST api/<controller>
        public void Post([FromBody]Story value)
        {
            _StoryRepo.CreateStory(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Story value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}