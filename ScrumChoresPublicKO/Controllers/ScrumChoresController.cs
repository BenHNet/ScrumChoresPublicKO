using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumChoresPublicKO.Controllers
{
    public class ScrumChoresController : Controller
    {
        // GET: ScrumChores
        public ActionResult Home()
        {
            return View();
        }
        // GET: ChoreList
        public ActionResult ChoreList()
        {
            return View();
        }
        // GET: ChoreBoard
        public ActionResult ChoreBoard()
        {
            return View();
        }
    }
}