﻿#pragma checksum "..\..\registerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "216740D44DE795B759654B5004C2413535272F67EAFC0792FAEF0599F4A9917F"
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
using RootLibrary.WPF.Localization;
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
    /// registerWindow
    /// </summary>
    public partial class registerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNama;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUser;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbManager;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbKoki;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPelayan;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbKasir;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgKaryawan;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btRegis;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDelete;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btUpdate;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\registerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passBox;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectPCS;component/registerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\registerWindow.xaml"
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
            
            #line 8 "..\..\registerWindow.xaml"
            ((ProjectPCS.registerWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbNama = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.rbManager = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\registerWindow.xaml"
            this.rbManager.Checked += new System.Windows.RoutedEventHandler(this.rbManager_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rbKoki = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\registerWindow.xaml"
            this.rbKoki.Checked += new System.Windows.RoutedEventHandler(this.rbKoki_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rbPelayan = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\registerWindow.xaml"
            this.rbPelayan.Checked += new System.Windows.RoutedEventHandler(this.rbPelayan_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rbKasir = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\registerWindow.xaml"
            this.rbKasir.Checked += new System.Windows.RoutedEventHandler(this.rbKasir_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgKaryawan = ((System.Windows.Controls.DataGrid)(target));
            
            #line 21 "..\..\registerWindow.xaml"
            this.dgKaryawan.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dgKaryawan_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btRegis = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\registerWindow.xaml"
            this.btRegis.Click += new System.Windows.RoutedEventHandler(this.btRegis_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btDelete = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\registerWindow.xaml"
            this.btDelete.Click += new System.Windows.RoutedEventHandler(this.btDelete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\registerWindow.xaml"
            this.btUpdate.Click += new System.Windows.RoutedEventHandler(this.btUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 25 "..\..\registerWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            return;
            case 13:
            this.passBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

