﻿#pragma checksum "..\..\VoucherWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2FFF3CB0EDFF86A9CFEBFE5168BAD438F6E0418E"
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
    /// VoucherWindow
    /// </summary>
    public partial class VoucherWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgVoucher;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbId;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNama;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDiskon;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btInsert;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btUpdate;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btClear;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDelete;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSearch;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btReset;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbExp;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\VoucherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAvail;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectPCS;component/voucherwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VoucherWindow.xaml"
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
            
            #line 8 "..\..\VoucherWindow.xaml"
            ((ProjectPCS.VoucherWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgVoucher = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\VoucherWindow.xaml"
            this.dgVoucher.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dgVoucher_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbId = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.tbNama = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbDiskon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btInsert = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\VoucherWindow.xaml"
            this.btInsert.Click += new System.Windows.RoutedEventHandler(this.btInsert_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\VoucherWindow.xaml"
            this.btUpdate.Click += new System.Windows.RoutedEventHandler(this.btUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btClear = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\VoucherWindow.xaml"
            this.btClear.Click += new System.Windows.RoutedEventHandler(this.btClear_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btDelete = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\VoucherWindow.xaml"
            this.btDelete.Click += new System.Windows.RoutedEventHandler(this.btDelete_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.tbSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.btSearch = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\VoucherWindow.xaml"
            this.btSearch.Click += new System.Windows.RoutedEventHandler(this.btSearch_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btReset = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\VoucherWindow.xaml"
            this.btReset.Click += new System.Windows.RoutedEventHandler(this.btReset_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.rbExp = ((System.Windows.Controls.RadioButton)(target));
            
            #line 29 "..\..\VoucherWindow.xaml"
            this.rbExp.Checked += new System.Windows.RoutedEventHandler(this.rbExp_Checked);
            
            #line default
            #line hidden
            return;
            case 14:
            this.rbAvail = ((System.Windows.Controls.RadioButton)(target));
            
            #line 30 "..\..\VoucherWindow.xaml"
            this.rbAvail.Checked += new System.Windows.RoutedEventHandler(this.rbAvail_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

