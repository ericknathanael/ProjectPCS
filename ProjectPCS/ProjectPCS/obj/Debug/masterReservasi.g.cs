﻿#pragma checksum "..\..\masterReservasi.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6EF58C7F335EB4E31B9ABB4D6B15C418EDBC3D8B"
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
    /// masterReservasi
    /// </summary>
    public partial class masterReservasi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image picHome;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgReservasi;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxNamaPelanggan;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxMeja;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerTanggal;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonInsert;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonUpdate;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDelete;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClear;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelID;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textboxJam;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\masterReservasi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxMenit;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectPCS;component/masterreservasi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\masterReservasi.xaml"
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
            this.picHome = ((System.Windows.Controls.Image)(target));
            
            #line 10 "..\..\masterReservasi.xaml"
            this.picHome.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.picHome_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgReservasi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\masterReservasi.xaml"
            this.dgReservasi.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dgReservasi_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboBoxNamaPelanggan = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.comboBoxMeja = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.datePickerTanggal = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.buttonInsert = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\masterReservasi.xaml"
            this.buttonInsert.Click += new System.Windows.RoutedEventHandler(this.buttonInsert_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\masterReservasi.xaml"
            this.buttonUpdate.Click += new System.Windows.RoutedEventHandler(this.buttonUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\masterReservasi.xaml"
            this.buttonDelete.Click += new System.Windows.RoutedEventHandler(this.buttonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.buttonClear = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\masterReservasi.xaml"
            this.buttonClear.Click += new System.Windows.RoutedEventHandler(this.buttonClear_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.labelID = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.textboxJam = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\masterReservasi.xaml"
            this.textboxJam.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextboxJam_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 12:
            this.textBoxMenit = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\masterReservasi.xaml"
            this.textBoxMenit.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBoxMenit_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

