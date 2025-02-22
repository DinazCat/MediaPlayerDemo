﻿using Media_Player.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Media_Player.View;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Reflection;
using Media_Player.Model;
using System.Data.SqlClient;
using System.Data;

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public static PlayList MaybeulikeList;
        public static PlayList PopularList;
        public static PlayList NewReleasesList;
        List<PlayList> artistPLs;
        public HomeView()
        {
            //this.DataContext = this;
            InitializeComponent();

            MaybeulikeList = new PlayList();
            InitList(ref MaybeulikeList, "Có Thể Bạn Sẽ Thích");
            listCothebansethich.ItemsSource = MaybeulikeList.songs;

            PopularList = new PlayList();
            InitList(ref PopularList, "Phổ Biến");
            listPhobien.ItemsSource= PopularList.songs;

            NewReleasesList = new PlayList();
            InitList(ref NewReleasesList, "Mới Phát Hành");
            listMoiphathanh.ItemsSource= NewReleasesList.songs;

            artistPLs = new List<PlayList>();
            listNghesi.ItemsSource = artistPLs;
            string[] artistName = new string[5] {
                "Taylor Swift", "Charlie Puth", "Alec Benjamin", "Harry Styles", "Big Bang"
            };
            string[] artistThumbnail = new string[5] {
                "TaylorSwift.jpg", "CharliePuth.jpg", "AlecBenjamin.jpg", "HarryStyles.webp", "BigBang.png"
            };
            for (int k = 0; k < 5; k++)
            {
                artistPLs.Add(new PlayList()
                {
                    picture = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + artistThumbnail[k],
                    title = artistName[k]
                });
            }
        }

        public EventHandler onAction = null;
        
        void InitList(ref PlayList pl, string PlaylistName)
        {
            //Đổ các dữ liệu cơ bản của playlist
            String query = "SELECT * FROM Playlist WHERE Title=@Title";

            SqlParameter param = new SqlParameter("@Title", PlaylistName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    DataRow dr = dt.Rows[0];
                    pl.title = dr[0].ToString();
                    pl.picture = dr[1].ToString();
                }
            }
            //Đổ dữ liệu cho songs
            pl.songs = new List<Song>();
            query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Belong B JOIN Song S ON S.Name=B.SongName WHERE PlaylistName=@PlaylistName";
            SqlParameter param1 = new SqlParameter("@PlaylistName", PlaylistName);
            using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
            {
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    int n = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        pl.songs.Add(new Song()
                        {
                            songName = dr["Name"].ToString(),
                            singerName = dr["Artist"].ToString(),
                            album = dr["Album"].ToString(),
                            linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString(),
                            savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString(),
                            time = dr["Duration"].ToString(),
                            getPL = PlaylistName
                        });
                        n++;
                    }
                    foreach (Song s in pl.songs)
                    {
                        s.getList = pl.songs;
                    }
                }
            }

        }

        PlayListView page = new PlayListView();
        UserControl p;
        private void ButtonArtist_Click(object sender, RoutedEventArgs e)
        {
            PlayList playList = (sender as Button).DataContext as PlayList;
            if (MainWindow.getListName != null && MainWindow.getListName == playList.title)
            {
                page = new PlayListView(MainWindow.getList, playList.title);
            }
            else
            {
                MainWindow.getListName = playList.title;
                List<Song> songs = new List<Song>();
                string query = "SELECT DISTINCT S.Name, Artist, Album, Duration, Thumbnail, Savepath FROM Song S WHERE Artist=@Artist";
                SqlParameter param1 = new SqlParameter("@Artist", playList.title);
                using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                {
                    DataTable dt = new DataTable();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        int n = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            Song s = new Song();
                            s.songName = dr[0].ToString();
                            s.singerName = dr[1].ToString();
                            s.album = dr[2].ToString();
                            s.linkanh = AppDomain.CurrentDomain.BaseDirectory + "Pictures/" + dr["Thumbnail"].ToString();
                            s.savepath = AppDomain.CurrentDomain.BaseDirectory + "Songs/" + dr["Savepath"].ToString();
                            s.time = dr["Duration"].ToString();
                            s.getPL = playList.title;
                            if (PlayListView.CheckLiked(s.songName) == true)
                                s.LinkLikeIcon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png";
                            songs.Add(s);

                            n++;
                        }
                        foreach (Song s in songs)
                        {
                            s.getList = songs;
                        }
                    }
                }

                page = new PlayListView(songs, playList.title);
            }
            p = page;
            MainWindow.nvgPlayListView(p);
        }

        private void viewAllListBtn_click(object sender, RoutedEventArgs e)
        {
            string s = (sender as Button).Name;
            switch (s) 
            {
                case "viewallMaybeulikeL":
                    page = new PlayListView(MaybeulikeList.songs, "Có Thể Bạn Sẽ Thích");
                    break;
                case "viewallPopularL":
                    page = new PlayListView(PopularList.songs, "Phổ Biến");
                    break;
                case "viewallNewReleasesL":
                    page = new PlayListView(NewReleasesList.songs, "Mới Phát Hành");
                    break;
            }
            p = page;
            MainWindow.nvgPlayListView(p);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 170);
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 170);
        }
    }
}
