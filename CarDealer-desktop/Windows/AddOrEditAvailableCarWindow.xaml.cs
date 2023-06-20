using CarDealer_desktop.Models;
using CarDealer_desktop.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarDealer_desktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditAvailableCarWindow.xaml
    /// </summary>
    public partial class AddOrEditAvailableCarWindow : Window
    {
        AvailableCar AvailableCar { get; set; }
        public AddOrEditAvailableCarWindow(AvailableCar availableCar)
        {
            InitializeComponent();
            AvailableCar = availableCar;
            if (AvailableCar != null && AvailableCar.MileAge != null || AvailableCar.Owners != null || AvailableCar.Vin != null)
            {
                AcId_Label.Content = $"№{AvailableCar.Id}";
                MileAge_TextBox.Text = AvailableCar.MileAge;
                Owners_TextBox.Text = AvailableCar.Owners.ToString();
                VIN_TextBox.Text = AvailableCar.Vin;
                CanOrder_Combobox.SelectedIndex = AvailableCar.CanOrder;
                AddOrEditAC_Button.Content = "Изменить";
            }
            else
            {
                AcId_Label.Visibility = Visibility.Hidden;
                RemoveAC_Button.Visibility = Visibility.Hidden;
            }
        }

        private void AddOrEditAC_Button_Click(object sender, RoutedEventArgs e)
        {           
            if(!string.IsNullOrEmpty(MileAge_TextBox.Text) && !string.IsNullOrEmpty(Owners_TextBox.Text) && !string.IsNullOrEmpty (VIN_TextBox.Text) && VIN_TextBox.Text.Length == 17)
            {
                AvailableCar availableCar = CDContext.cdContext.AvailableCars.Where(ac => ac.Vin == VIN_TextBox.Text).FirstOrDefault();
                if (availableCar != null && AvailableCar != availableCar)
                {
                    MessageBox.Show("Автомобиль с таким VIN уже существует", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                if (AddOrEditAC_Button.Content == "Изменить")
                {
                    AvailableCar.MileAge = MileAge_TextBox.Text;
                    AvailableCar.Vin = VIN_TextBox.Text;
                    AvailableCar.Owners = Int32.Parse(Owners_TextBox.Text);
                    AvailableCar.CanOrder = CanOrder_Combobox.SelectedIndex;
                    CDContext.cdContext.SaveChanges();
                    MessageBox.Show("автомобиль в наличии успешно изменен");
                    Close();
                }
                else
                {
                    AvailableCar.MileAge = MileAge_TextBox.Text;
                    AvailableCar.Vin = VIN_TextBox.Text;
                    AvailableCar.Owners = Int32.Parse(Owners_TextBox.Text);
                    AvailableCar.CanOrder = CanOrder_Combobox.SelectedIndex;
                    CDContext.cdContext.AvailableCars.Add(AvailableCar);
                    CDContext.cdContext.SaveChanges();
                    MessageBox.Show("автомобиль в наличии успешно добавлен");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RemoveAC_Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = CDContext.cdContext.Orders.Where(o => o.AvailableCar == AvailableCar).FirstOrDefault();
            if (order == null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    CDContext.cdContext.AvailableCars.Remove(AvailableCar);
                    CDContext.cdContext.SaveChanges();
                    MessageBox.Show("Вы успешно удалили автомобиль в наличии");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Данный автомобиль в налчии есть в заказе", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void Owners_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void MileAge_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void VIN_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {           
            e.Handled = !Regex.Match(e.Text, @"[0-9]|[A-Z]").Success;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
