﻿#pragma checksum "..\..\..\..\Windows\UsersWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F4D8FED78DFDA1EC04F9838E5B5D3DA47FA1EBE5"
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
    /// UsersWindow
    /// </summary>
    public partial class UsersWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search_TextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ManagerFio_Label;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Buyers_ViewList;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EmptySearch_Label;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEditBuyer_Button;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChooseBuyer_Button;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel_Button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.18.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarDealer-desktop;component/windows/userswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\UsersWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.18.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Search_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\..\Windows\UsersWindow.xaml"
            this.Search_TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ManagerFio_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Buyers_ViewList = ((System.Windows.Controls.ListView)(target));
            
            #line 26 "..\..\..\..\Windows\UsersWindow.xaml"
            this.Buyers_ViewList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Buyers_ViewList_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\Windows\UsersWindow.xaml"
            this.Buyers_ViewList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Buyers_ViewList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EmptySearch_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.AddEditBuyer_Button = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Windows\UsersWindow.xaml"
            this.AddEditBuyer_Button.Click += new System.Windows.RoutedEventHandler(this.AddEditBuyer_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ChooseBuyer_Button = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Windows\UsersWindow.xaml"
            this.ChooseBuyer_Button.Click += new System.Windows.RoutedEventHandler(this.ChooseBuyer_Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Cancel_Button = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Windows\UsersWindow.xaml"
            this.Cancel_Button.Click += new System.Windows.RoutedEventHandler(this.Cancel_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

