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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            CDContext.cdContext.Database.CanConnect();
        }

        public static User? user1 { get; set; }

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            string pass;
            if(ShowHidePass_CheckBox.IsChecked == false)
            {
                pass = Password_PassBox.Password;
            }
            else
            {
                pass = Password_TextBox.Text;
            }
            if (CDContext.cdContext.Database.CanConnect())
            {

                user1 = CDContext.cdContext.Users.FirstOrDefault(m => m.Login == Login_TextBox.Text && m.Password == pass);
                if (user1 != null)
                {
                    Hide();
                    MessageBox.Show($"Добро пожаловать, {string.Join(" ", user1.LastName, user1.FirstName, user1.Patronymic)}, вы вошли как {user1.UserRole.Title}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    CurrentUser.currentUser = user1;
                    var m1 = new MainWindow();
                    m1.Owner = this;
                    m1.Show();
                    Password_TextBox.Text = default;
                    Password_PassBox.Password = default;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Уведомление");
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к базе данных cardealer", "Ошибка подключения");
            }
        }

        private void ShowHidePass_CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            Password_TextBox.Visibility = Visibility.Visible;
            Password_PassBox.Visibility = Visibility.Hidden;
            Password_TextBox.Text = Password_PassBox.Password;
        }

        private void ShowHidePass_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Password_TextBox.Visibility = Visibility.Hidden;
            Password_PassBox.Visibility = Visibility.Visible;
            Password_PassBox.Password = Password_TextBox.Text;
        }
    }
}
