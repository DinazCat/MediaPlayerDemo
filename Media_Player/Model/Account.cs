using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.Model
{
    internal class Account : INotifyPropertyChanged
    {
        private string UserName;
        private string Picture;
        private string Password;
        private string Email;
        private string DisplayName;
        public string displayName
        {
            get { return DisplayName; }
            set { DisplayName = value; OnPropertyChanged("DisplayName"); }
        }
        public string picture
        {
            get { return Picture; }
            set { Picture = value; OnPropertyChanged("Picture"); }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; OnPropertyChanged("Email"); }
        }
        public string userName
        {
            get { return UserName; }
            set { UserName = value; OnPropertyChanged("UserName"); }
        }
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
