﻿using System;
using System.Collections.Generic;
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

namespace Media_Player.UserControls
{
    /// <summary>
    /// Interaction logic for SongItem.xaml
    /// </summary>
    public partial class SongItem : UserControl
    {
        public SongItem()
        {
            InitializeComponent();
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(SongItem));

        public string Artist
        {
            get { return (string)GetValue(ArtistProperty); }
            set { SetValue(ArtistProperty, value); }
        }
        public static readonly DependencyProperty ArtistProperty = DependencyProperty.Register("Artist", typeof(string), typeof(SongItem));
        public string Album
        {
            get { return (string)GetValue(AlbumProperty); }
            set { SetValue(AlbumProperty, value); }
        }
        public static readonly DependencyProperty AlbumProperty = DependencyProperty.Register("Album", typeof(string), typeof(SongItem));

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(SongItem));
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(SongItem));

        public bool IsLiked
        {
            get { return (bool)GetValue(IsLikedProperty); }
            set { SetValue(IsLikedProperty, value); }
        }
        public static readonly DependencyProperty IsLikedProperty = DependencyProperty.Register("IsLiked", typeof(bool), typeof(SongItem));
    }
}