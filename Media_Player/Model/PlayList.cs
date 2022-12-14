using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.Model
{
    public class PlayList : INotifyPropertyChanged
    {
        private string Title;
        private string Picture;
        private string Description;
        private int Duration;
        private List<Song> Songs;
        //public ObservableCollection<Song> Songs { get; set; }
        private bool HaveOpened = false;
        public bool haveOpened { get { return HaveOpened; } set { HaveOpened = value; } }
        public string title { get { return Title; } set { Title = value; } }
        public string picture { get { return Picture; } set { Picture = value; } }
        public string description { get { return Description; } set { Description = value; } }
        public int duration { get { return Duration; } set { Duration = value; } }
        public List<Song> songs { get { return Songs; } set { Songs = value; } }
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
