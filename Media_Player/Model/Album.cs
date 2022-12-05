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
        private string Title { get; set; }
        private string Artist { get; set; }
        private string Genres { get; set; }
        private string Thumbnail { get; set; }
        private uint Year { get; set; }
    }
}
