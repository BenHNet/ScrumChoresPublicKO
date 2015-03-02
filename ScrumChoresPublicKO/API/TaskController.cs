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
    public class TaskController : ApiController
    {
        private ISprintTaskRepository _sprintTaskRepo;

        public TaskController()
            : this(new SprintTaskRepository())
        {
        }

        public TaskController(ISprintTaskRepository repoSprintTask)
        {
            _sprintTaskRepo = repoSprintTask;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public SprintTask Get(int id)
        {
            return new SprintTask();
        }

        // POST api/<controller>
        public void Post([FromBody]SprintTask value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]SprintTask value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}