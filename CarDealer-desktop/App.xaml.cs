using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WinForms = System.Windows.Forms;
using System.Windows;

namespace CarDealer_desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            base.OnStartup(e);
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Application.Current.Shutdown();
            WinForms.Application.Restart();
            //System.Diagnostics.Process.Start(location);          
            //Exception e = (Exception)args.ExceptionObject;          
            //MessageBox.Show(e.Message + $"  {location}");

        }
    }
}
