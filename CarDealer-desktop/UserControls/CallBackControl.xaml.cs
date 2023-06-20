using CarDealer_desktop.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarDealer.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CallBackControl.xaml
    /// </summary>
    public partial class CallBackControl : UserControl
    {
        public Callrequest CallReq { get; set; }
        public CallBackControl(Callrequest callreq)
        {
            InitializeComponent();
            CallReq = callreq;
            CountOrder_Label.Content = "Заявка №" + CallReq.Id.ToString();
            Status_Label.Content = "Статус заявки: " + CallReq.Status.Title;
            DateOrder_Label.Content = "Дата заявки: " + CallReq.DateRequest.ToString();
            if (CurrentUser.currentUser.UserRoleId == 1 || CurrentUser.currentUser.UserRoleId == 2)
            {
                if (CallReq.Manager != null)
                {
                    isManager_Label.Content = $"Менеджер: {string.Join(" ", CallReq.Manager.LastName, CallReq.Manager.FirstName, CallReq.Manager.Patronymic)}";
                }
                else
                {
                    isManager_Label.Content = "Не назначена";
                }
            }
            if (CallReq.StatusId == 3)
            {
                Status_Label.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(195, 30, 58));
            }
            else if (CallReq.StatusId == 2)  
            {
                Status_Label.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(205, 164, 52));
            }
            else if (CallReq.StatusId == 4)
            {
                Status_Label.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(205, 20, 60));
            }
            else
            {
                Status_Label.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(50,205,0));
            }
        }
    }
}
