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
using System.Windows.Shapes;

namespace CarDealer.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditOrAddOrdersWindow.xaml
    /// </summary>
    public partial class EditOrAddOrdersWindow : Window
    {
        private Order order { get; set; }
        private Equipment selEquipment { get; set; }
        public EditOrAddOrdersWindow(Order orders, Equipment equipments, Buyer buyers)
        {
            InitializeComponent();
            order = orders;
            foreach(Equipment equip in CDContext.cdContext.Equipments.ToList())
            {
                Equipment_Combobox.Items.Add(equip);
            }
            foreach (User buyer1 in CDContext.cdContext.Users.Where(u => u.UserRoleId == 4).ToList())
            {
                if(buyer1.LastName != null && buyer1.Patronymic != null && buyer1.Address != null && buyer1.Passport != null && buyer1.Birthday != null)
                    Buyer_Combobox.Items.Add(buyer1);
            }
            if(CurrentUser.currentUser.UserRoleId == 3)
            {
                AvailableCar_Combobox.IsEnabled = false;
            }
            if(orders != null)
            {
                AddEditOrder_Button.Content = "Изменить";
                DeleteOrder_Button.Visibility = Visibility.Visible; 
                order = orders;
                Equipment_Combobox.SelectedItem = CDContext.cdContext.Equipments.Where(e => e.Id == orders.EquipmentId).FirstOrDefault();
                Buyer_Combobox.SelectedItem = CDContext.cdContext.Users.Where(b => b.Id == orders.BuyerId).FirstOrDefault();
                OrderDate_Label.Content = orders.Date.ToString();

            }
            else
            {
                DeleteOrder_Button.Visibility = Visibility.Hidden;

            }
            if (equipments != null)
            {

                Equipment_Combobox.SelectedItem = CDContext.cdContext.Equipments.Where(e => e.Id == equipments.Id).FirstOrDefault();
                
            }
            if(buyers != null)
            {
                Buyer_Combobox.SelectedItem = CDContext.cdContext.Users.Where(b => b.Id == buyers.Id).FirstOrDefault();
            }
            DataContext = this;
        }

        private void UpdateAvailableCars()
        {                     
            for (int i = AvailableCar_Combobox.Items.Count - 1; i > 0; i--)
            {
                AvailableCar_Combobox.Items.RemoveAt(i);
            }
            foreach (AvailableCar availableCar in CDContext.cdContext.AvailableCars.Where(ac => ac.Equipment.Id == selEquipment.Id))
            {
                AvailableCar_Combobox.Items.Add(availableCar);
            }
            if (order != null)
            {
                if(order.AvailableCar != null)
                {
                    if(selEquipment.Id == order.AvailableCar.EquipmentId){

                        AvailableCar_Combobox.SelectedItem = (AvailableCar)order.AvailableCar;
                    }
                    else
                    {
                        AvailableCar_Combobox.SelectedIndex = 0;
                    }
                }
            }
        }

        private void AddEditOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            int year = Int32.Parse(DateTime.Now.ToString("yyyy"));
            int month = Int32.Parse(DateTime.Now.ToString("MM"));
            int day = Int32.Parse(DateTime.Now.ToString("dd"));
            DateOnly date = new DateOnly(year, month, day);
            if (AddEditOrder_Button.Content.ToString() == "Добавить")
            {
                order = new Order();
                order.Date = date;
                order.ManagerId = CurrentUser.currentUser.Id;
                order.Equipment = (Equipment)Equipment_Combobox.SelectedItem;
                order.Buyer = (User)Buyer_Combobox.SelectedItem;
                if(AvailableCar_Combobox.SelectedIndex > 0)
                {
                    order.AvailableCar = (AvailableCar)AvailableCar_Combobox.SelectedItem;
                }
                CDContext.cdContext.Orders.Add(order);
                CDContext.cdContext.SaveChanges();
                MessageBox.Show("Заказ успешно создан");
                Close();
            }
            else
            {
                var result = MessageBox.Show("Вы действительно хотите изменить?", "Уведомление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (AvailableCar_Combobox.SelectedIndex > 0)
                    {
                        order.AvailableCar = (AvailableCar)AvailableCar_Combobox.SelectedItem;
                    }
                    else
                    {
                        order.AvailableCar = null;
                    }
                    order.Equipment = (Equipment)Equipment_Combobox.SelectedItem;
                    order.Buyer = (User)Buyer_Combobox.SelectedItem;
                    CDContext.cdContext.SaveChanges();
                    MessageBox.Show("Заказ изменен");
                    Close();
                }
            }
        }

        private void DeleteOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (AddEditOrder_Button.Content.ToString() == "Изменить")
                {
                    CDContext.cdContext.Orders.Remove(order);
                    CDContext.cdContext.SaveChanges();
                    MessageBox.Show("Заказ успешно удален");
                    Close();
                }
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Equipment_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            selEquipment = (Equipment)Equipment_Combobox.SelectedItem;
            UpdateAvailableCars();
        }
    }
}
