using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.Model
{
    internal class Artist
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public int SongCount { get; set; }
        public int AlbumCount { get; set; }
    }
}
