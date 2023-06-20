using CarDealer.UserControls;
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
    /// Логика взаимодействия для UserssWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public static List<User> DisplayUsers = new List<User>();
        User currentUser { get; set; }
        public UsersWindow()
        {
            InitializeComponent();
            ManagerFio_Label.Content = string.Join(" ", CurrentUser.currentUser.LastName, CurrentUser.currentUser.FirstName, CurrentUser.currentUser.Patronymic);   
            UpdateBuyers();
        }
        private Double GetNormalWidth()
        {
            if (WindowState == WindowState.Maximized)
                return RenderSize.Width - 50;

            else
                return Width - 50;
        }
        
        private void UpdateBuyers()
        {   
            if(CurrentUser.currentUser.UserRoleId == 3)
            {
                DisplayUsers = CDContext.cdContext.Users.Where(u => u.UserRoleId == 4).ToList();
            }
            else
            {
                DisplayUsers = CDContext.cdContext.Users.Where(u => u.UserRoleId == 4 || u.UserRoleId == 3).ToList();
            }
            if (!string.IsNullOrEmpty(Search_TextBox.Text))
            {
                DisplayUsers = DisplayUsers.Where(b => b.FirstName.ToLower().Contains(Search_TextBox.Text.ToLower()) || b.Phone.ToLower().Contains(Search_TextBox.Text.ToLower())).ToList();
            }
            Buyers_ViewList.Items.Clear();
            foreach (User buyers in DisplayUsers)
            {
                Buyers_ViewList.Items.Add(new BuyersControl(buyers) { Width = GetNormalWidth() });
            }
            if(Buyers_ViewList.Items.Count == 0)
            {
                EmptySearch_Label.Visibility = Visibility.Visible;
            }
            else
            {
                EmptySearch_Label.Visibility = Visibility.Hidden;
            }
        }

        private void Buyers_ViewList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            User buyers = ((BuyersControl)Buyers_ViewList.SelectedItem).Buyers;
            new EditOrAddBuyersWindow(buyers).ShowDialog();
            UpdateBuyers();

        }

        private void AddEditBuyer_Button_Click(object sender, RoutedEventArgs e)
        {
            new EditOrAddBuyersWindow(null).ShowDialog();
            UpdateBuyers();
        }

        private void Search_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBuyers();
        }

        private void ChooseBuyer_Button_Click(object sender, RoutedEventArgs e)
        {
            if(currentUser != null)
            {
                CurrentUser.currentUser = currentUser;
                Close();
            }
        }

        private void Buyers_ViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Buyers_ViewList.SelectedItem != null)
            {
                currentUser = ((BuyersControl)Buyers_ViewList.SelectedItem).Buyers;
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
