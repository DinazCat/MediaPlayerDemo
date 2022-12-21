using Media_Player.Model;
using Media_Player.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Media_Player.ViewModel
{

    public static class Phatnhac
    {
        public static MediaPlayer mediaPlayer = new MediaPlayer();
        private static List<Song> Occupying;
        public static List<Song> occupying { get { return Occupying; } set { Occupying = value; } }
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
        private static bool _shuffle = false;
        private static bool _repeat = false;
        private static bool _autoplay = true;
        public static bool isshuffle { get { return _shuffle; } set { _shuffle = value; } }
        public static bool isrepeat { get { return _repeat; } set { _repeat = value; } }
        public static bool isAutoplay { get { return _autoplay; } set { _autoplay = value; } }
        private static Song _thisSong;
        public static Song thisSong { get { return _thisSong; } set { _thisSong = value; } }
        private static List<Song> _thisList;
        public static List<Song> thisList { get { return _thisList; } set { _thisList = value; } }
        public static bool listened = false;
        public static string filename;
        public static void openmusic()
        {
            mediaPlayer.Open(new Uri(filename));
            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }
       
        private static void MediaPlayer_MediaOpened(object? sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                thisSong.duration = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                ((MainWindow)System.Windows.Application.Current.MainWindow).txblDuration.Text
                    = new TimeSpan(0, (int)(thisSong.duration / 60), (int)(thisSong.duration % 60)).ToString(@"mm\:ss");
                ((MainWindow)System.Windows.Application.Current.MainWindow).timelineSlider.Maximum = thisSong.duration;
                thisSong.Position = 0;
                MainWindow.oldPosition = 0;
                mediaPlayer.Position = new TimeSpan(0, 0, 0);
                if (!isInit)
                {
                    isInit = true;
                    return;
                }
                MainWindow.Timer.Start();
            }
        }
        private static void MediaPlayer_MediaEnded(object? sender, EventArgs e)
        {
            thisSong.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
            ((MainWindow)System.Windows.Application.Current.MainWindow).BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));

            if (isrepeat)
            {
                thisSong.Open = true;
                HamTuongTac(thisSong);
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    thisSong.duration = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txblDuration.Text
                        = new TimeSpan(0, (int)(thisSong.duration / 60), (int)(thisSong.duration % 60)).ToString(@"mm\:ss");
                    ((MainWindow)System.Windows.Application.Current.MainWindow).timelineSlider.Maximum = thisSong.duration;
                    thisSong.Position = 0;
                    mediaPlayer.Position = new TimeSpan(0, 0, 0);
                    MainWindow.Timer.Start();
                }
            }
            else if (isshuffle)
            {
                thisSong.Open = true;
                int curindex = thisList.IndexOf(thisSong), index;
                do
                {
                    Random random = new Random();
                    index = random.Next(0, thisList.Count);
                } while (curindex == index);
                MainWindow.getSong = thisList[index];
                HamTuongTac(thisList[index]);
            }
            else if(isAutoplay) 
            {
                thisSong.Open = true;
                int curindex = thisList.IndexOf(thisSong);
                curindex++;
                if (curindex < thisList.Count)
                {
                    MainWindow.getSong = thisList[curindex];
                    HamTuongTac(thisList[curindex]);
                }
            }            
        }
        public static void SqlInteract(string m)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(m, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }    
        public static void HamTuongTac(Song song)
        {
            if (song.Open == true)
            {
                mediaPlayer.Stop();
                for (int i = 0; i < thisList.Count; i++)
                {
                    if (thisList[i].Open == false) thisList[i].Open = true;
                    thisList[i].Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                }
                if (occupying != null)
                    for (int i = 0; i < occupying.Count; i++)
                    {
                        if (occupying[i].Open == false) occupying[i].Open = true;
                        occupying[i].Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                    }
                ((MainWindow)System.Windows.Application.Current.MainWindow).Anh.Source = new BitmapImage(new Uri(song.linkanh));
                ((MainWindow)System.Windows.Application.Current.MainWindow).TenBH.Content = song.songName;
                ((MainWindow)System.Windows.Application.Current.MainWindow).TenTG.Content = song.singerName;
                if(MainWindow.userName != null)
                {
                    string query = "SELECT * FROM Listenrecently L JOIN Song S ON L.Songname = S.Name WHERE UserName = @username Order by  STT DESC";
                    SqlParameter param1 = new SqlParameter("@username", MainWindow.userName);
                    DataTable dt;
                    using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                    {
                        dt = new DataTable();
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Songname"].ToString() == song.songName) listened = true;
                        }
                        if (listened == false)
                        {
                            if (dt.Rows.Count < 11)
                            {
                                string m = "Insert into [Listenrecently] values(N'" + MainWindow.userName + "',N'" + song.songName + "','" + dt.Rows.Count + "' )";
                                SqlInteract(m);
                            }
                            else
                            {
                                string m = "Insert into [Listenrecently] values(N'" + MainWindow.userName + "',N'" + song.songName + "','" + dt.Rows.Count + "' )";
                                SqlInteract(m);

                                m = "delete from [Listenrecently] where STT='" + 0 + "' and UserName = '" + MainWindow.userName + "'";
                                SqlInteract(m);

                                m = "Update [Listenrecently] Set STT = STT - 1 where UserName = '" + MainWindow.userName + "'";
                                SqlInteract(m);
                            }
                        }
                        else
                        {
                            string m = "delete from [Listenrecently] where Songname =N'" + song.songName + "' and UserName = N'" + MainWindow.userName + "'";
                            SqlInteract(m);

                            m = "Update [Listenrecently] Set STT = STT - 1 where UserName = '" + MainWindow.userName + "'";
                            SqlInteract(m);

                            m = "Insert into [Listenrecently] values(N'" + MainWindow.userName + "',N'" + song.songName + "','" + dt.Rows.Count + "' )";
                            SqlInteract(m);
                        }
                    }
                    else
                    {
                        string m = "Insert into [Listenrecently] values(N'" + MainWindow.userName + "',N'" + song.songName + "','" + 0 + "' )";
                        SqlInteract(m);
                    }
                    listened = false;

                    query = "SELECT * FROM Liked L JOIN Song S ON L.Songname = S.Name WHERE UserName = @username Order by  STT DESC";
                    param1 = new SqlParameter("@username", MainWindow.userName);
                    using (SqlDataReader reader = DataProvider.ExecuteReader(query, CommandType.Text, param1))
                    {
                        dt = new DataTable();
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["Songname"].ToString() == song.songName)
                                {
                                    song.isLike = true;
                                    ((MainWindow)System.Windows.Application.Current.MainWindow).Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "RedHeart.png"));
                                }

                            }
                        }
                    }
                    if (song.isLike == false)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).Heart.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "heart.png"));

                    }
                }    
                
            }
        
            filename = song.savepath;

            if (song.Open == true)
            {
                isplaying = true;
                openmusic();
                song.Open = false;
            }

            isplaying = !isplaying;
            if (isplaying == true)
            {
                song.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png";
                ((MainWindow)System.Windows.Application.Current.MainWindow).BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "play.png"));
                MainWindow.Timer.Stop();
            }
            else
            {
                song.Linkicon = AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png";
                ((MainWindow)System.Windows.Application.Current.MainWindow).BtnPlay2.Content = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Icon\\" + "pause.png"));
                MainWindow.Timer.Start();
            }

            MainWindow.getSong = song;
            thisSong = song;
           
        }
        private static bool isInit = false;
        public static void Init()
        {
            thisList = GenresView.getPopL;
            thisSong = GenresView.getPopL[0];
            MainWindow.getListName = "Nhạc Pop";            
            ((MainWindow)System.Windows.Application.Current.MainWindow).Anh.Source = new BitmapImage(new Uri(thisSong.linkanh));
            ((MainWindow)System.Windows.Application.Current.MainWindow).TenBH.Content = thisSong.songName;
            ((MainWindow)System.Windows.Application.Current.MainWindow).TenTG.Content = thisSong.singerName;
            filename = thisSong.savepath;
            openmusic();
        }
    }
}
