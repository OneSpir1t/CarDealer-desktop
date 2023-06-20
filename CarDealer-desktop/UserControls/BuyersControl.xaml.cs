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
using CarDealer_desktop.Models;

namespace CarDealer.UserControls
{
    /// <summary>
    /// Логика взаимодействия для BuyersControl.xaml
    /// </summary>
    public partial class BuyersControl : UserControl
    {
        public User Buyers { get; set; }
        public BuyersControl(User buyers)
        {
            InitializeComponent();
            Buyers = buyers;
            FirstName_Label.Content = "Имя: " + buyers.FirstName;
            if (buyers.LastName != null)
            {
                LastName_Label.Content = "Фамилия: " + buyers.LastName;
            }
            else
            {
                LastName_Label.Visibility = Visibility.Hidden;
            }
            if (buyers.Patronymic != null)
            {
                Patryonomic_Label.Content = "Отчество: " + buyers.Patronymic;
            }
            else
            {
                Patryonomic_Label.Visibility = Visibility.Hidden;
            }
        }
    }
}
