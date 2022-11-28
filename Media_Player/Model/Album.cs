using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.Model
{
    internal class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genres { get; set; }
        public string Thumbnail { get; set; }
        public uint Year { get; set; }
    }
}
