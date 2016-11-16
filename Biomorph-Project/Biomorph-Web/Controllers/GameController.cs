using Biomorph.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biomorph_Web.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult NewWorld()
        {
            return View("Index",new World());
        }
    }
}