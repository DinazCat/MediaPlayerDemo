﻿#pragma checksum "..\..\..\..\View\SendCode.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B42D224F2B38311C349F89D8BDFBBDE88E4B5EDB"
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
using Media_Player.View;
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


namespace Media_Player.View {
    
    
    /// <summary>
    /// SendCode
    /// </summary>
    public partial class SendCode : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\View\SendCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Errortxt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\SendCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.ColorZone verifyCode;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\View\SendCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCode;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\View\SendCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.ColorZone email;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\View\SendCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbEmail;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\View\SendCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnsendcode;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\View\SendCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnverifycode;
        
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
            System.Uri resourceLocater = new System.Uri("/Media_Player;component/view/sendcode.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\SendCode.xaml"
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
            
            #line 14 "..\..\..\..\View\SendCode.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 24 "..\..\..\..\View\SendCode.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Errortxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.verifyCode = ((MaterialDesignThemes.Wpf.ColorZone)(target));
            return;
            case 5:
            this.txbCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.email = ((MaterialDesignThemes.Wpf.ColorZone)(target));
            return;
            case 7:
            this.txbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnsendcode = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\View\SendCode.xaml"
            this.btnsendcode.Click += new System.Windows.RoutedEventHandler(this.SendCode_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnverifycode = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\View\SendCode.xaml"
            this.btnverifycode.Click += new System.Windows.RoutedEventHandler(this.VerifyCode_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

