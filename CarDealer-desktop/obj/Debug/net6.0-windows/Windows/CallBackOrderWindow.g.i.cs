﻿#pragma checksum "..\..\..\..\Windows\CallBackOrderWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98DDC9AD356580A1E2C81B46FEC421FCB7EF37BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarDealer.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace CarDealer.Windows {
    
    
    /// <summary>
    /// CallBackOrderWindow
    /// </summary>
    public partial class CallBackOrderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CallBackOrdersList_View;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EmptyOrders_Label;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WhichOfCallsReq_Combobox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortCallReq_Combobox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarDealer-desktop;component/windows/callbackorderwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
            ((CarDealer.Windows.CallBackOrderWindow)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CallBackOrdersList_View = ((System.Windows.Controls.ListView)(target));
            
            #line 15 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
            this.CallBackOrdersList_View.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.CallBackOrdersList_View_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
            this.CallBackOrdersList_View.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CallBackOrdersList_View_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EmptyOrders_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.WhichOfCallsReq_Combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
            this.WhichOfCallsReq_Combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.WhichOfCallReq_Combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SortCallReq_Combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
            this.SortCallReq_Combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortCallReq_Combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 32 "..\..\..\..\Windows\CallBackOrderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

