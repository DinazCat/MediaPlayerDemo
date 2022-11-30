using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.Model
{
    internal class PlayList
    {
        private string Title;
        private string Picture;
        private string Description;
        private string Duration;
        private List<Song> Songs;
        private bool HaveOpened = false;
        public bool haveOpened { get { return HaveOpened; } set { HaveOpened = value; } }
        public string title { get { return Title; } set { Title = value; } }
        public string picture { get { return Picture; } set { Picture = value; } }
        public string description { get { return Description; } set { Description = value; } }
        public string duration { get { return Duration; } set { Duration = value; } }
        public List<Song> songs { get { return Songs; } set { Songs = value; } }
    }
}
