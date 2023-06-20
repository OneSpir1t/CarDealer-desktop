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

namespace CarDealer_desktop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AvailableCarControl.xaml
    /// </summary>
    public partial class AvailableCarsControl : UserControl
    {
        public AvailableCar AvailableCar { get; set; }
        public AvailableCarsControl(AvailableCar availableCar)
        {
            InitializeComponent();
            AvailableCar = availableCar;
            MileAge_Label.Content = availableCar.MileAge;
            Owners_Label.Content = availableCar.Owners.ToString();
            VIN_Label.Content = availableCar.Vin.ToString();
            if (availableCar.CanOrder == 1)
            {
                CanOrder_Label.Content = "Доступно к заказу";
                CanOrder_Label.Background = Brushes.Green;
            }
            else
            {
                CanOrder_Label.Content = "Недоступно к заказу";
                CanOrder_Label.Background = Brushes.IndianRed;
            }

        }
    }
}
