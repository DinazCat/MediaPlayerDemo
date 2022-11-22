using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Media_Player.ViewModel
{

    public static class Phatnhac
    {
        public static MediaPlayer mediaPlayer = new MediaPlayer();
        private static bool isplaying2 = true;
        public static bool Isplaying2 { get { return isplaying2; } set { isplaying2 = value; } }
        private static bool _playing = true;
        public static bool isplaying
        {
            get
            {
                return _playing;
            }
            set
            {
                _playing = value;
                if (_playing)
                {
                    mediaPlayer.Pause();
                }
                else
                {
                    mediaPlayer.Play();
                }
            }
        }
    }
}
