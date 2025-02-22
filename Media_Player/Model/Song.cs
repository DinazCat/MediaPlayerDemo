﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Media_Player.Model
{
    public class Song : INotifyPropertyChanged
    {
        private string SongName;
        private string SingerName;
        private string Album;
        private string Linkanh;
        private string SavePath;
        private bool open = true;
        private string linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
        private double Duration;
        private string Time;
        private double position;
        private string GetPl;
        
        public string Linkicon
        {
            get { return linkicon; }
            set { linkicon = value; OnPropertyChanged("Linkicon"); }
        }
        public bool Open { get { return open; } set { open = value; } }
        public string songName { get => SongName; set => SongName = value; }
        public string singerName { get => SingerName; set => SingerName = value; }
        public string album { get => Album; set => Album = value; }
        public string linkanh { get => Linkanh; set => Linkanh = value; }
        public string savepath { get => SavePath; set => SavePath = value; }
        public double duration { get => Duration; set => Duration = value; }
        public string time { get => Time; set => Time = value; }
        public double Position { get => position; set => position = value; }
        public string getPL { get { return GetPl; } set { GetPl = value; } }

        private List<Song> GetList;
        public List<Song> getList { get { return GetList; } set { GetList = value; } }
        private string GetLoaiPL = "";
        public string getLoaiPL { get { return GetLoaiPL; } set { GetLoaiPL = value; } }
        private string linkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png";
        public string LinkLikeIcon
        {
            get { return linkLikeIcon; }
            set { linkLikeIcon = value; OnPropertyChanged("LinkLikeIcon"); }
        }
        private bool IsLike = false;
        public bool isLike { get => IsLike; set => IsLike = value; }

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
