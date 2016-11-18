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
            var world = new World();
            world.GenerateWorld();
            world.TestCurrentGen();

            var worldMapper = new Mappers.WorldMapper();
            return View("Index", worldMapper.Map(world));
        }
    }
}