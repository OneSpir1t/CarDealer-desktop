using CarDealer.UserControls;
using CarDealer_desktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarDealer.Windows
{
    /// <summary>
    /// Логика взаимодействия для CallBackOrderWindow.xaml
    /// </summary>
    public partial class CallBackOrderWindow : Window
    {
        public Callrequest currentCallReq { get; set; }
        public static List<Callrequest> DisplayCallReq = new List<Callrequest>();
        public CallBackOrderWindow()
        {   
            
            InitializeComponent();
            WhichOfCallsReq_Combobox.Items.Add("Все заявки");
            WhichOfCallsReq_Combobox.Items.Add("Не назначенные");
            WhichOfCallsReq_Combobox.Items.Add("Открытые заявки");
            SortCallReq_Combobox.Items.Add("Сначала новые");
            SortCallReq_Combobox.Items.Add("Сначала старые");
            DataContext = this;
            if (CurrentUser.currentUser.UserRoleId == 3)
            {
                WhichOfCallsReq_Combobox.Visibility = Visibility.Hidden;
            }
            UpdateCallReqList();
        }

        public void UpdateCallReqList()
        {
            CallBackOrdersList_View.Items.Clear();
            DisplayCallReq = CDContext.cdContext.Callrequests.OrderByDescending(i => i.Id).ToList();
            if(CurrentUser.currentUser.UserRoleId == 3)
            {
                DisplayCallReq = DisplayCallReq.Where(cr => cr.ManagerId == CurrentUser.currentUser.Id).ToList();
            }            
            if (WhichOfCallsReq_Combobox.SelectedIndex > 0)
            {
                switch (WhichOfCallsReq_Combobox.SelectedIndex)
                {
                    case 1:
                        DisplayCallReq = DisplayCallReq.Where(m => m.Manager == null).ToList();
                        break;
                    case 2:
                        DisplayCallReq = DisplayCallReq.Where(s => s.Status.Id == 1).ToList();
                        break;
                }
            }
            if(SortCallReq_Combobox.SelectedIndex > -1)
            {
                switch (SortCallReq_Combobox.SelectedIndex)
                {
                    case 0:
                        DisplayCallReq = DisplayCallReq.OrderByDescending(i => i.DateRequest).ToList();
                        break;
                    case 1:
                        DisplayCallReq = DisplayCallReq.OrderBy(i => i.DateRequest).ToList();
                        break;
                }
            }
            foreach(Callrequest callrequest in DisplayCallReq)
            {
                if (callrequest.AvailableCar != null)
                {
                    if (callrequest.AvailableCar.CanOrder == 0 && callrequest.StatusId != 3)
                    {
                        callrequest.StatusId = 4;
                    }
                    CDContext.cdContext.SaveChanges();
                }
                if (callrequest.Equipment != null)
                {
                    if (callrequest.Equipment.CanOrder == 0 && callrequest.StatusId != 3)
                    {
                        callrequest.StatusId = 4;
                    }
                    CDContext.cdContext.SaveChanges();
                }
                CallBackOrdersList_View.Items.Add(new CallBackControl(callrequest) {Width = GetNormalWidth() });
            }
            if (DisplayCallReq.Count == 0)
            {
                EmptyOrders_Label.Visibility = Visibility.Visible;
            }
            else
            {
                EmptyOrders_Label.Visibility = Visibility.Hidden;
            }
        }
        private Double GetNormalWidth()
        {
            if (WindowState == WindowState.Maximized)
                return RenderSize.Width - 50;

            else
                return Width - 50;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (CallBackControl item in CallBackOrdersList_View.Items)
            {
                item.Width = GetNormalWidth();
            }
        }

        private void WhichOfCallReq_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCallReqList();
        }

        private void CallBackOrdersList_View_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(currentCallReq != null)
            {
                new AnswerCallWindow(currentCallReq, CurrentUser.currentUser).ShowDialog();
                UpdateCallReqList();
            }
        }

        private void CallBackOrdersList_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CallBackOrdersList_View.SelectedItem != null)
            {
                currentCallReq = ((CallBackControl)CallBackOrdersList_View.SelectedItem).CallReq;
            }
        }

        private void SortCallReq_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCallReqList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
