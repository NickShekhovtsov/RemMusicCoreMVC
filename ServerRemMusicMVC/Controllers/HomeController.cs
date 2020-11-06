using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using ServerRemMusicMVC.Models;

namespace ServerRemMusicMVC.Controllers
{
    public class HomeController : Controller
    {
        public _Socket server;
        public void  ServerStart()
        {
            server=new _Socket(8000);
        }
        
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {   
            ViewData["Message"] = "Your application description page.";
            ViewData["Play"] = "Play";
            SongArray sa=new SongArray();
            
            sa.array = new List<Song>();
            sa.array.Add(new Song("Rammst", 15));
            sa.array.Add(new Song("Prodigy", 5));
            sa.array.Add(new Song("Omen", 3));
            sa.array.Add(new Song("KiSh", 2));
            sa.array.Add(new Song("Leningrad", 1));


            return View(sa);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
