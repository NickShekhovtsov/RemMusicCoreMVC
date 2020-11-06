using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServerRemMusicMVC.Models;

namespace ServerRemMusicMVC
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            //_Socket server = new _Socket(8000);
            _Socket serverhtml = new _Socket(8800);
            ////отображение списка треков с компьютера на сайте
            //динамическое построение списка треков
            //    разделение хтмл на человеческую структуру(хтмл и css раздельно)
            ////_Socket server = new _Socket();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
