using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.Model
{
    public class Album : INotifyPropertyChanged
    {
        private string Title;
        private string Artist;
        private string Thumbnail;
        private uint Year;
        public string title { get { return Title; } set { Title = value; } }
        public string artist { get { return Artist; } set { Artist = value; } }
        public string thumbnail { get { return Thumbnail; } set { Thumbnail = value; } }
        public uint year { get { return Year; } set { Year = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newname));
            }
        }
    }
}
