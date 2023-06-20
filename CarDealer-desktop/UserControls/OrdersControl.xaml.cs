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
    /// Логика взаимодействия для OrdersControl.xaml
    /// </summary>
    public partial class OrdersControl : UserControl
    {
        public Order Orders { get; set; }
        public OrdersControl(Order orders)
        {
            InitializeComponent();
            Orders = orders;
            Buyer_Label.Content = "Покупатель: " + string.Join(" ", orders.Buyer.LastName, orders.Buyer.FirstName);
            NumOrder_Label.Content = $"Заказ №{orders.Id}";
            if(orders.Equipment!= null)
            {
                EquipmentName_Label.Content = "Комплектация: " + orders.Equipment.Title;
                Mark_Label.Content = "Марка: " + orders.Equipment.Model.Brand.Title;
                Model_Label.Content = "Модель: " + orders.Equipment.Model.Title;
                DateOrder_Label.Content = "Дата заказа: " + orders.Date.ToString();
                PhoneBuyer_Label.Content = "Номер телефона: " + orders.Buyer.Phone;
            }
        }
    }
}
