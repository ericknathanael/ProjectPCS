﻿#pragma checksum "..\..\ManagerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9B0EE6C3529CD2F1772B77382D2EBC7E06FF34650182CFD902289D73469B00C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectPCS;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ProjectPCS {
    
    
    /// <summary>
    /// ManagerWindow
    /// </summary>
    public partial class ManagerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btRegis;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btMenu;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btLaporan;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAbsensi;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbWelcome;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btLogout;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btGenerate;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbKode;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btVoucher;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectPCS;component/managerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ManagerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\ManagerWindow.xaml"
            ((ProjectPCS.ManagerWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btRegis = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\ManagerWindow.xaml"
            this.btRegis.Click += new System.Windows.RoutedEventHandler(this.btRegis_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btMenu = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ManagerWindow.xaml"
            this.btMenu.Click += new System.Windows.RoutedEventHandler(this.btMenu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btLaporan = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ManagerWindow.xaml"
            this.btLaporan.Click += new System.Windows.RoutedEventHandler(this.btLaporan_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btAbsensi = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ManagerWindow.xaml"
            this.btAbsensi.Click += new System.Windows.RoutedEventHandler(this.btAbsensi_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbWelcome = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btLogout = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\ManagerWindow.xaml"
            this.btLogout.Click += new System.Windows.RoutedEventHandler(this.btLogout_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btGenerate = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\ManagerWindow.xaml"
            this.btGenerate.Click += new System.Windows.RoutedEventHandler(this.btGenerate_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lbKode = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.btVoucher = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\ManagerWindow.xaml"
            this.btVoucher.Click += new System.Windows.RoutedEventHandler(this.btVoucher_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

