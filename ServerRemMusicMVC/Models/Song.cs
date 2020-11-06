using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerRemMusicMVC.Models
{
    public class Song
    {
        public string name { get; set; }
        public uint duration { get; set; }
        public Song(string _name, uint _duration)
        {
            name = _name;
            duration = _duration;
        }
    }
}
