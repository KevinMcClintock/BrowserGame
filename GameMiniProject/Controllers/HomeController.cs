using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMiniProject.Models;

namespace GameMiniProject.Controllers
{
    public class HomeController : Controller
    {
            [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Heroic Trails: Seekers of Infamy.";

            return View();
        }

        public ActionResult About()
        {
            var model = new aboutModel();
            model.Information = "Game Information";
            model.aboutGame = "The lord of the kingdom has determined a method through which to rank the heroes in his domain. Heroes from across the kingdom gather together daily for rigorous training by way of arena combat for a yearly tournament to determine the strongest hero of the realm.";
           
            return View(model);
        }

        public ActionResult Tutorial()
        {
            ViewBag.Message = "Tutorial infomation.";
            ViewBag.tutorialInfo = "Heroic Trials: Seekers of Infamy (HT) is an arena game where you control a character in a multi-player environment against one other player character. The aim of the game is to defeat the enemy player as fast as possible using all resources available to you to do so.";
            ViewBag.controlScheme = " You gain control of either a knight or a thief, to control your hero around the battlefield screen you will use this control scheme.";
           
            return View();
        }
    }
}
