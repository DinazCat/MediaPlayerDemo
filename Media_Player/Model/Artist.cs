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
        private string Name { get; set; }
        private string Picture { get; set; }
        private int SongCount { get; set; }
        private int AlbumCount { get; set; }
    }
}
