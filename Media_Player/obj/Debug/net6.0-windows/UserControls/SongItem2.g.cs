﻿#pragma checksum "..\..\..\..\UserControls\SongItem2.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D75436180D9906DCFD85875CBC4A097C2A3A0DE0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Media_Player.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Media_Player.UserControls {
    
    
    /// <summary>
    /// SongItem2
    /// </summary>
    public partial class SongItem2 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel ucitem2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush Picture;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPlay;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu songItemContextMenu;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem deleteSongFromPL;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem userPlaylistMenuItem;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addSongToPlayingList;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\UserControls\SongItem2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addSongToPlayNext;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Media_Player;component/usercontrols/songitem2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\SongItem2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\UserControls\SongItem2.xaml"
            ((System.Windows.Controls.Border)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.songpnl_mouseEnter);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\UserControls\SongItem2.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.songpnl_mouseLeave);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\UserControls\SongItem2.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.songItem_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ucitem2 = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.Picture = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 4:
            this.BtnPlay = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\UserControls\SongItem2.xaml"
            this.BtnPlay.Click += new System.Windows.RoutedEventHandler(this.BtnPlay_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 42 "..\..\..\..\UserControls\SongItem2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.artistBtn_click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.songItemContextMenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 7:
            this.deleteSongFromPL = ((System.Windows.Controls.MenuItem)(target));
            
            #line 49 "..\..\..\..\UserControls\SongItem2.xaml"
            this.deleteSongFromPL.Click += new System.Windows.RoutedEventHandler(this.deleteSongFromCurPL_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.userPlaylistMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 54 "..\..\..\..\UserControls\SongItem2.xaml"
            this.userPlaylistMenuItem.Click += new System.Windows.RoutedEventHandler(this.addSongToUserPL_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.addSongToPlayingList = ((System.Windows.Controls.MenuItem)(target));
            
            #line 70 "..\..\..\..\UserControls\SongItem2.xaml"
            this.addSongToPlayingList.Click += new System.Windows.RoutedEventHandler(this.addSongToPlayingList_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.addSongToPlayNext = ((System.Windows.Controls.MenuItem)(target));
            
            #line 75 "..\..\..\..\UserControls\SongItem2.xaml"
            this.addSongToPlayNext.Click += new System.Windows.RoutedEventHandler(this.addSongToPlayNext_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 60 "..\..\..\..\UserControls\SongItem2.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.playlist_MouseDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

