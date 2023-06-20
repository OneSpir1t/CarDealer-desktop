using CarDealer_desktop.Models;
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

namespace CarDealer.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditOrAddBuyersWindow.xaml
    /// </summary>
    public partial class EditOrAddBuyersWindow : Window
    {
        User user { get; set; }

        private DateOnly dateToday = new DateOnly();

        public EditOrAddBuyersWindow(User buyer)
        {
            InitializeComponent();
            Birtday_DatePicker.DisplayDateEnd = DateTime.Now.AddYears(-18);
            
            if(CurrentUser.currentUser.UserRoleId == 3)
            {
                foreach(UserRole userRole in CDContext.cdContext.UserRoles.Where(ur => ur.Id == 4).ToList()){

                    UserRole_Combobox.Items.Add(userRole);
                }
                UserRole_Combobox.SelectedIndex = 0;
                UserRole_Combobox.IsEnabled = false;
            }
            else
            {
                foreach (UserRole userRole in CDContext.cdContext.UserRoles.Where(ur => ur.Id == 3 || ur.Id == 4).ToList())
                {

                    UserRole_Combobox.Items.Add(userRole);
                }
            }
            if(buyer != null)
            {
                UserRole_Combobox.IsEnabled = false;
                this.user = buyer;
                UserRole_Combobox.SelectedItem = this.user.UserRole;
                AddEditBuyer_Button.Content = "Изменить";
                if(this.user.Birthday != null)
                {
                    DateOnly dateOnly = (DateOnly)this.user.Birthday;                        
                    Birtday_DatePicker.SelectedDate = dateOnly.ToDateTime(TimeOnly.Parse("10:00 PM"));
                }
            }
            else
            {
                this.user = new User();
                this.user.UserRoleId = 4;
                Birtday_DatePicker.SelectedDate = DateTime.Now.AddYears(-18);
                this.user.Phone = "7";
                DeleteBuyer_Button.Visibility = Visibility.Hidden;
            }
            DataContext = this.user;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddEditBuyer_Button_Click(object sender, RoutedEventArgs e)
        {
            if(user.FirstName == null || user.LastName == null ||
                user.Address == null || Passport_Textbox.Text.Length < 10 || Phone_Textbox.Text.Length < 11)
            {
                MessageBox.Show("Заполните поля");
            }
            else if(Birtday_DatePicker.SelectedDate != null)
            {
                User userlog = CDContext.cdContext.Users.Where(u => u.Login == Login_TextBox.Text).FirstOrDefault();
                if(userlog == null || user == userlog)
                {

                    if(AddEditBuyer_Button.Content.ToString() == "Добавить")
                    {
                        user.UserRole = (UserRole)UserRole_Combobox.SelectedItem;
                        user.Birthday = DateOnly.FromDateTime((DateTime)Birtday_DatePicker.SelectedDate);
                        CDContext.cdContext.Users.Add(user);
                        CDContext.cdContext.SaveChanges();
                        MessageBox.Show($"{user.UserRole.Title} успешно добавлен", "Уведомление");
                        Close();
                
                    }
                    else
                    {
                        user.UserRole = (UserRole)UserRole_Combobox.SelectedItem;
                        user.Birthday = DateOnly.FromDateTime((DateTime)Birtday_DatePicker.SelectedDate);
                        CDContext.cdContext.SaveChanges();
                        MessageBox.Show("Данные успешно изменены", "Уведомление");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            else
            {
                MessageBox.Show("Выберите дату");
            }
        }

        private void DeleteBuyer_Button_Click(object sender, RoutedEventArgs e)
        {
            if (user.UserRoleId == 3)
            {
                if (user.CallrequestManagers.Count != 0 || user.OrderManagers.Count != 0)
                {
                    var result =  MessageBox.Show("У данного менеджера есть заявка/заказ, вы действительно хотите удалить покупателя?", "Уведомление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        RemoveUser();
                    }
                    return;
                }
                else
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        RemoveUser();
                    }
                }
            }
            else if (user.CallrequestBuyers.Count == 0 && user.OrderBuyers.Count == 0)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    RemoveUser();
                }
            }
            else
            {       
                var result = MessageBox.Show("У данного покупателя есть заявка/заказ, вы действительно хотите удалить покупателя?", "Уведомление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    RemoveUser();
                }
            }
        }

        private void RemoveUser()
        {           
                string userrolename = user.UserRole.Title;
                CDContext.cdContext.Users.Remove(user);
                CDContext.cdContext.SaveChanges();
                MessageBox.Show($"{userrolename} успешно удалён");
                Close();           
        }

        private void Passport_Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void Phone_Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void LastName_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.Match(e.Text, @"[а-яА-Я]|[a-zA-Z]").Success;
        }

        private void FirstName_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.Match(e.Text, @"[а-яА-Я]|[a-zA-Z]").Success;
        }

        private void Patronymic_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.Match(e.Text, @"[а-яА-Я]|[a-zA-Z]").Success;
        }

        private void LastName_TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void FirstName_TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Patronymic_TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Passport_Textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Phone_Textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void UserRole_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserRole role = UserRole_Combobox.SelectedItem as UserRole;
            if (role.Id == 4)
            {
                Login_TextBox.Visibility = Visibility.Hidden;
                Login_Label.Visibility = Visibility.Hidden;
                Password_TextBox.Visibility = Visibility.Hidden;
                Password_Label.Visibility = Visibility.Hidden;
            }
            else
            {
                Login_TextBox.Visibility = Visibility.Visible;
                Login_Label.Visibility = Visibility.Visible;
                Password_TextBox.Visibility = Visibility.Visible;
                Password_Label.Visibility = Visibility.Visible;
            }

        }
    }
}
