﻿#pragma checksum "..\..\..\..\Windows\AuthorizationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C892C8E6CB1AD282C92E37A0D5FDCBA0D928410"
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
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// AuthorizationWindow
    /// </summary>
    public partial class AuthorizationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Windows\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login_TextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Password_TextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Windows\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password_PassBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Windows\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ShowHidePass_CheckBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Windows\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogIn_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/CarDealer-desktop;component/windows/authorizationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\AuthorizationWindow.xaml"
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
            this.Login_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Password_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Password_PassBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.ShowHidePass_CheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 29 "..\..\..\..\Windows\AuthorizationWindow.xaml"
            this.ShowHidePass_CheckBox.Checked += new System.Windows.RoutedEventHandler(this.ShowHidePass_CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\..\Windows\AuthorizationWindow.xaml"
            this.ShowHidePass_CheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.ShowHidePass_CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LogIn_Button = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Windows\AuthorizationWindow.xaml"
            this.LogIn_Button.Click += new System.Windows.RoutedEventHandler(this.LogIn_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

