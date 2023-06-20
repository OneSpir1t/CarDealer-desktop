using CarDealer_desktop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
    /// Логика взаимодействия для CarsControl.xaml
    /// </summary>
    public partial class CarsControl : UserControl
    {
        public Equipment Equipment { get; set; }
        public CarsControl(Equipment equipments)
        {            
            InitializeComponent();
            DataContext = this;
            Equipment = equipments;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Equipment != null)
            {
                Mark_Label.Content = Equipment.Model.Brand.Title;
                Country_Label.Content = Equipment.Model.Brand.Country.Title;
                ModelName_Label.Content = Equipment.Model.Title + ", " + Equipment.TechnicalInformation.Yearofmanufacture;
                BodyType_Label.Content = "Тип кузова: " + Equipment.TechnicalInformation.BodyType.Title;
                Color_Label.Content = "Цвет: " + Equipment.TechnicalInformation.Color.Title;
                EngineType_Label.Content = "Тип двигателя: " + Equipment.TechnicalInformation.EngineType.Title;
                Enginedisplacement_Label.Content = $"Объем двигателя: {Equipment.TechnicalInformation.Enginedisplacement}";
                CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
                Cost_Label.Content = Equipment.Cost.ToString("0,0", elGR) + " ₽";
                HorsePower_Label.Content = "Кол-во л.с. " + Equipment.TechnicalInformation.Horsepower;
                string mainPhotosPath = Environment.CurrentDirectory + "/CarImages/";
                int countAvailable = 0;
                if (Equipment.CanOrder == 1)
                {
                    CanOrder_Label.Content = "Доступно к заказу";
                    CanOrder_Label.Background = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    CanOrder_Label.Content = "Недоступно к заказу";
                    CanOrder_Label.Background = System.Windows.Media.Brushes.IndianRed;
                }
                foreach (AvailableCar availableCar in CDContext.cdContext.AvailableCars.Where(ac => ac.EquipmentId == Equipment.Id).ToList())
                {
                    countAvailable++;
                }
                if (countAvailable > 0)
                    isAviableCar_Label.Content = "В наличии";
                else isAviableCar_Label.Visibility = Visibility.Hidden;
                if (Equipment.Image != null && Equipment.Image.Length > 3)
                {
                    if (System.IO.File.Exists(mainPhotosPath + Equipment.Image))
                        Car_Image.Source = new BitmapImage(new Uri(mainPhotosPath + Equipment.Image));
                    else
                    {
                        Car_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/defaultImage.png"));
                    }
                }
                else
                {
                    Car_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/defaultImage.png"));
                }
            }
        }
    }
}
