﻿#pragma checksum "..\..\KasirWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07D00360EBAE122DF1E45EFC12BC06FC870F036C"
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
    /// KasirWindow
    /// </summary>
    public partial class KasirWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\KasirWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btLogout;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\KasirWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image picTrans;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\KasirWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image picPesan;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\KasirWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image picAbsen;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\KasirWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbNama;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectPCS;component/kasirwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\KasirWindow.xaml"
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
            
            #line 8 "..\..\KasirWindow.xaml"
            ((ProjectPCS.KasirWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btLogout = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\KasirWindow.xaml"
            this.btLogout.Click += new System.Windows.RoutedEventHandler(this.btLogout_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.picTrans = ((System.Windows.Controls.Image)(target));
            
            #line 16 "..\..\KasirWindow.xaml"
            this.picTrans.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.picPesan = ((System.Windows.Controls.Image)(target));
            
            #line 17 "..\..\KasirWindow.xaml"
            this.picPesan.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.picPesan_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.picAbsen = ((System.Windows.Controls.Image)(target));
            
            #line 18 "..\..\KasirWindow.xaml"
            this.picAbsen.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.picAbsen_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbNama = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

