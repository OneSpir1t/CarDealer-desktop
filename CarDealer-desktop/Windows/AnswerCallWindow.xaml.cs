using CarDealer_desktop.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CarDealer.Windows
{
    /// <summary>
    /// Логика взаимодействия для AnswerCallWindow.xaml
    /// </summary>
    public partial class AnswerCallWindow : Window
    {
        private DateOnly date { get; set; }
        Callrequest callrequest { get; set; }
        public AnswerCallWindow(Callrequest Callrequest, User user)
        {   
            InitializeComponent();
            callrequest = Callrequest;
            int year = Int32.Parse(DateTime.Now.ToString("yyyy"));
            int month = Int32.Parse(DateTime.Now.ToString("MM"));
            int day = Int32.Parse(DateTime.Now.ToString("dd"));
            date = new DateOnly(year, month, day);
            if (CurrentUser.currentUser.UserRoleId > 2)
            {
                SetManager_Border.Height = 0;
                if(Callrequest.DateStart == null)
                {
                    Callrequest.DateStart = date;
                    if(Callrequest.StatusId == 1)
                    {
                        Callrequest.StatusId = 2;
                    }
                    CDContext.cdContext.SaveChanges();
                }
                if(Callrequest.StatusId == 3)
                {
                    CloseCallReq_Button.Visibility = Visibility.Hidden;
                }
                else
                {
                    CloseCallReq_Button.Visibility = Visibility.Visible;
                }
            }
            if (Callrequest.Equipment != null || Callrequest.Manager != null || Callrequest.Buyer != null)
            {
                Mark_Label.Content = callrequest.Equipment.Model.Brand.Title;
                Country_Label.Content = Callrequest.Equipment.Model.Brand.Country.Title;
                ModelName_Label.Content = Callrequest.Equipment.Model.Title + ", " + Callrequest.Equipment.TechnicalInformation.Yearofmanufacture.ToString();
                BodyType_Label.Content = "Тип кузова: " + Callrequest.Equipment.TechnicalInformation.BodyType.Title;
                Color_Label.Content = "Цвет: " + Callrequest.Equipment.TechnicalInformation.Color.Title;
                EngineType_Label.Content = "Тип двигателя: " + Callrequest.Equipment.TechnicalInformation.EngineType.Title;
                CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
                Cost_Label.Content = Callrequest.Equipment.Cost.ToString("0,0", elGR) + " ₽";
                HorsePower_Label.Content = "Кол-во л.с.: " + Callrequest.Equipment.TechnicalInformation.Horsepower;
                string mainPhotosPath = Environment.CurrentDirectory + "/CarImages/";
                NumCallReq_Label.Content = $"Заявка №{Callrequest.Id}";
                StatusCallReq_Label.Content = $"Статус: {Callrequest.Status.Title}";
                if (Callrequest.Equipment.Image != null && Callrequest.Equipment.Image.Length > 3)
                {
                    if (System.IO.File.Exists(mainPhotosPath + Callrequest.Equipment.Image))
                        Car_Image.Source = new BitmapImage(new Uri(mainPhotosPath + Callrequest.Equipment.Image));
                    else
                    {
                        Car_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/defaultImage.png"));
                    }
                }
                else
                {
                    Car_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/defaultImage.png"));
                }
                Name_Label.Content = "Имя: " + Callrequest.Buyer.FirstName;
                Phone_Label.Content = "Телефон: " + Callrequest.Buyer.Phone;
                //Callrequest.ManagerId = user.Id;
                //Callrequest.StatusId = 2;
                //CDContext.cdContext.SaveChanges();
            }       
            if(Callrequest.AvailableCar != null)
            {
                Vin_Label.Content = $"VIN: {Callrequest.AvailableCar.Vin}";
                MileAge_Lable.Content = $"Пробег: {Callrequest.AvailableCar.MileAge}";
                Owners_Label.Content = $"Владельцев: {Callrequest.AvailableCar.Owners}";
                if (Callrequest.AvailableCar.Owners == 0)
                {
                    Owners_Label.Visibility = Visibility.Hidden;
                }
            }
            foreach(User manager in CDContext.cdContext.Users.Where(u => u.UserRoleId == 3).ToList())
            {
                ManagerReq_Combobox.Items.Add(manager);
            }
            
            if(Callrequest.Manager != null)
            {
                ManagerReq_Combobox.SelectedItem = Callrequest.Manager;
                ManagerReq_Combobox.IsEnabled = false;
                SetManager_Button.Visibility = Visibility.Hidden;

            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetManager_Button_Click(object sender, RoutedEventArgs e)
        {
            if(callrequest.DateStart == null)
            {
                callrequest.Manager = (User)ManagerReq_Combobox.SelectedItem;
                CDContext.cdContext.SaveChanges();
                ManagerReq_Combobox.IsEnabled = false;
                SetManager_Button.Visibility = Visibility.Hidden;
                MessageBox.Show("Менеджер назначен");              
            }
        }

        private void CloseCallReq_Button_Click(object sender, RoutedEventArgs e)
        {
            callrequest.DateEnd = date;
            callrequest.StatusId = 3;

            CDContext.cdContext.SaveChanges();
            MessageBox.Show("Заявка успешно закрыта");
            Close();
        }
    }
}
