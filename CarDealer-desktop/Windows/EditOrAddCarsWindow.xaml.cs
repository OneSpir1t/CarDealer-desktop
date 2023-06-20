using Microsoft.Win32;
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
using System.IO;
using System.Data.Entity.Validation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using CarDealer_desktop.Models;
using CarDealer_desktop.UserControls;
using CarDealer.UserControls;
using CarDealer_desktop.Windows;

namespace CarDealer.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditOrAddCarsWindow.xaml
    /// </summary>
    public partial class EditOrAddCarsWindow : Window
    {
        AvailableCar CurrentAC { get; set; }
        public static bool isedited;
        Equipment equipments;
        static Equipment equipments1 { get; set; }
        OpenFileDialog ofd = new OpenFileDialog();
        string photoCar;
        string mainPhotosPath = Environment.CurrentDirectory + "/CarImages/";
        bool flag, flag2 = true;
        public EditOrAddCarsWindow(Equipment equipments)
        {
            InitializeComponent();
            isedited = false;
            CanOrder_Combobox.Items.Add("Нет");
            CanOrder_Combobox.Items.Add("Да");
            ofd.Filter = "All files (*.*)|*.*|Png files(*.png)|*.png|Jpg files(.*jpg)|*.jpg";
            Mark_Combobox.ItemsSource = CDContext.cdContext.Brands.ToList();
            BodyType_Combobox.ItemsSource = CDContext.cdContext.Bodytypes.ToList();
            TypeEngine_Combobox.ItemsSource = CDContext.cdContext.Enginetypes.ToList();
            Color_Combobox.ItemsSource = CDContext.cdContext.Colors.ToList();
            Transmission_Combobox.ItemsSource = CDContext.cdContext.Transmissions.ToList();
            DriveType_Combobox.ItemsSource = CDContext.cdContext.Drivetypes.ToList();
            var years = Enumerable.Range(2000, int.Parse(DateTime.Now.ToString("yy")) + 1);
            foreach (var year in years)
            {
                YearOfManufacture_Combobox.Items.Add(year);
            }
            for (int i = 1; i < 9; i++)
            {
                CountSeats_Combobox.Items.Add(i);
            }
            if (equipments != null)
            {
                this.equipments = equipments;
                if(equipments.Image != null && equipments.Image.Length > 3)
                {
                    if (File.Exists(mainPhotosPath + equipments.Image))
                        Car_Image.Source = new BitmapImage(new Uri(mainPhotosPath + equipments.Image));
                    else
                    {
                        Car_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/defaultImage.png"));
                    }
                }
                else
                {
                    Car_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/defaultImage.png"));
                }
                if(equipments.CanOrder == 0) {
                    CanOrder_Combobox.SelectedIndex = 0;
                }
                else
                {
                    CanOrder_Combobox.SelectedIndex = 1;
                }
                AddChange_Button.Content = "Изменить";
                equipments1 = equipments;
                UpdateAvailableCarsList();
                Mark_Combobox.SelectedItem = equipments.Model.Brand;
                ModelName_Textbox.Text = equipments.Model.Title;
                BodyType_Combobox.SelectedItem = equipments.TechnicalInformation.BodyType;
                TypeEngine_Combobox.SelectedItem = equipments.TechnicalInformation.EngineType;
                Color_Combobox.SelectedItem = equipments.TechnicalInformation.Color;
                Enginedisplacement_TextBox.Text = equipments.TechnicalInformation.Enginedisplacement;
                HorsePower_Textbox.Text = equipments.TechnicalInformation.Horsepower.ToString();
                YearOfManufacture_Combobox.SelectedItem = Int32.Parse(equipments.TechnicalInformation.Yearofmanufacture);
                CountSeats_Combobox.SelectedItem = equipments.TechnicalInformation.CountSeats;
                Transmission_Combobox.SelectedItem = equipments.TechnicalInformation.Transmission;
                DriveType_Combobox.SelectedItem = equipments.TechnicalInformation.DriveType;
            }
            else
            {
                ShowAC_Button.Visibility = Visibility.Hidden;
                DeleteEq_Button.Visibility = Visibility.Hidden;
                this.equipments = new Equipment();
                Car_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/defaultImage.png"));
            }
            DataContext = this.equipments;           
        }

        private Double GetNormalWidth()
        {
            if(this.Width >= 1230)
            {
                if (WindowState == WindowState.Maximized)
                    return RenderSize.Width - 640;

                else
                    return Width - 640;
            }
            else
            {
                return Width;
            }
        }

        

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddChange_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Cost_Textbox.Text) || string.IsNullOrEmpty(HorsePower_Textbox.Text) ||
                string.IsNullOrEmpty(ModelName_Textbox.Text) || string.IsNullOrEmpty(NameEq_Textbox.Text))
            {
                MessageBox.Show("Заполните поля");
            }
            else if (AddChange_Button.Content.ToString() == "Добавить")
            {


                try
                {
                    Model findModel = CDContext.cdContext.Models.Where(m => m.Title == ModelName_Textbox.Text && m.Brand == (Brand)Mark_Combobox.SelectedItem).FirstOrDefault();
                    if (findModel != null)
                    {
                        equipments.Model = findModel;
                    }
                    Equipment findByTitle = CDContext.cdContext.Equipments.Where(e => e.Title == equipments.Title).FirstOrDefault(); 
                    if (findByTitle != null && findModel != null)
                    {
                        MessageBox.Show("Комплектация с таким названием уже существует");
                        return;
                    }
                    else
                    {
                        Model models = new Model()
                        {
                            Title = ModelName_Textbox.Text,
                            Brand = (Brand)Mark_Combobox.SelectedItem
                        };
                        equipments.Model = models;
                    }
                    Technicalinformation technicalInformation = new Technicalinformation()
                    {
                        BodyType = (Bodytype)BodyType_Combobox.SelectedItem,
                        EngineType = (Enginetype)TypeEngine_Combobox.SelectedItem,
                        Color = (CarDealer_desktop.Models.Color)Color_Combobox.SelectedItem,
                        Horsepower = Convert.ToInt32(HorsePower_Textbox.Text),
                        CountSeats = Convert.ToInt32(CountSeats_Combobox.SelectedItem),
                        Yearofmanufacture = YearOfManufacture_Combobox.SelectedValue.ToString(),
                        Enginedisplacement = Enginedisplacement_TextBox.Text,
                        DriveType = (Drivetype)DriveType_Combobox.SelectedItem,
                        Transmission = (Transmission)Transmission_Combobox.SelectedItem
                    };
                    equipments.CanOrder = CanOrder_Combobox.SelectedIndex;
                    equipments.TechnicalInformation = technicalInformation;
                    if (photoCar != null)
                    {
                        string carImage = System.IO.Path.GetFileName(photoCar);
                        try
                        {
                            File.Copy(photoCar, Environment.CurrentDirectory + "/CarImages/" + carImage, true);                               
                            equipments.Image = carImage;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    CDContext.cdContext.Equipments.Add(equipments);
                    CDContext.cdContext.SaveChanges();
                    MessageBox.Show("Комплектиция добавлена");
                    isedited = true;
                    Close();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());

                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            MessageBox.Show(err.ErrorMessage + "");
                        }
                    }
                }
                
            }
            else
            {
                if (photoCar != null)
                {
                    string carImage = System.IO.Path.GetFileName(photoCar);
                    carImage = System.IO.Path.GetRandomFileName() + ".png";
                    File.Copy(photoCar, Environment.CurrentDirectory + "/CarImages/" + carImage, true);
                    equipments1.Image = carImage;
                }
                equipments1.Title = NameEq_Textbox.Text;
                equipments1.Model.Brand = (Brand)Mark_Combobox.SelectedItem;
                equipments1.Model.Title = ModelName_Textbox.Text;
                equipments1.TechnicalInformation.BodyType = (Bodytype)BodyType_Combobox.SelectedItem;
                equipments1.TechnicalInformation.EngineType = (Enginetype)TypeEngine_Combobox.SelectedItem;
                equipments1.Cost = float.Parse(Cost_Textbox.Text);
                equipments1.CanOrder = CanOrder_Combobox.SelectedIndex;
                equipments1.TechnicalInformation.Color = (CarDealer_desktop.Models.Color)Color_Combobox.SelectedItem;
                equipments1.TechnicalInformation.Horsepower = Convert.ToInt32(HorsePower_Textbox.Text);
                equipments1.TechnicalInformation.Yearofmanufacture = YearOfManufacture_Combobox.SelectedValue.ToString();
                equipments1.TechnicalInformation.CountSeats = Convert.ToInt32(CountSeats_Combobox.SelectedItem);
                equipments.TechnicalInformation.Transmission = (Transmission)Transmission_Combobox.SelectedItem;
                equipments.TechnicalInformation.DriveType = (Drivetype)DriveType_Combobox.SelectedItem;
                CDContext.cdContext.SaveChanges();
                isedited = true;
                Close();
                MessageBox.Show("Комплектация успешно изменена!");
                
            }

        }

        private void DeleteEq_Button_Click(object sender, RoutedEventArgs e)
        {
            if(equipments1.Callrequests.Count > 0)
            {
                MessageBox.Show("Комплектация есть в заявке", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (equipments1.AvailableCars.Count > 0)
            {
                MessageBox.Show("Комплектация eсть в наличии", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (CDContext.cdContext.Orders.Where(o => o.EquipmentId == equipments1.Id).FirstOrDefault() != null)
            {
                MessageBox.Show("Комплектация есть в заказе", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    CDContext.cdContext.Technicalinformations.Remove(equipments1.TechnicalInformation);
                    CDContext.cdContext.Equipments.Remove(equipments1);
                    CDContext.cdContext.SaveChanges();
                    MessageBox.Show("Вы успешно удалили комплектацию");
                    isedited = true;
                    Close();
                }
            }           
        }


        private void Cost_Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void HorsePower_Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;          
            
        }

        private void ChangeImage_Button_Click(object sender, RoutedEventArgs e)
        {
            if(ofd.ShowDialog() == true)
            {
                photoCar = ofd.FileName;
                Car_Image.Source = new BitmapImage(new Uri(photoCar));
            }
        }

        private void HorsePower_Textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Cost_Textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            if(Cost_Textbox.Text.Length == 0)
            {
                
            }
        }

        private void NameEq_Textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (NameEq_Textbox.Text.Length == 0)
            {
                if (e.Key == Key.Space)
                {
                    e.Handled = true;
                }
                flag = true;
            }
            else if (e.Key == Key.Space)
            {
                if (flag)
                {
                    flag = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            
        }

        private void AvailableCars_ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(CurrentAC != null)
            {
                var adoeacw = new AddOrEditAvailableCarWindow(CurrentAC).ShowDialog();
                UpdateAvailableCarsList();
                isedited = true;
            }
        }

        private void AvailableCars_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AvailableCars_ListView.SelectedItem != null)
            {
                CurrentAC = ((AvailableCarsControl)AvailableCars_ListView.SelectedItem).AvailableCar;
            }
        }

        private void UpdateAvailableCarsList()
        {
            AvailableCars_ListView.Items.Clear();
            foreach (AvailableCar availableCar in CDContext.cdContext.AvailableCars.Where(ac => ac.EquipmentId == equipments1.Id))
            {
                AvailableCars_ListView.Items.Add(new AvailableCarsControl(availableCar) { Width = GetNormalWidth()});
            }
            if (AvailableCars_ListView.Items.Count > 0)
            {
                this.Width = 1230;
                NotFound_Label.Visibility = Visibility.Hidden;
            }
            else
            {
                NotFound_Label.Visibility = Visibility.Visible;
            }
            AvailableCarsCount_Label.Content = $"В наличии: {AvailableCars_ListView.Items.Count}";
        }

        private void AddAC_Button_Click(object sender, RoutedEventArgs e)
        {
            AvailableCar availableCar = new AvailableCar();
            availableCar.Equipment = equipments1;
            var adoeacw = new AddOrEditAvailableCarWindow(availableCar).ShowDialog();
            UpdateAvailableCarsList();
            isedited = true;
        }

        private void ShowAC_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 1230;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (AvailableCarsControl item in AvailableCars_ListView.Items)
            {
                item.Width = GetNormalWidth();
            }
        }

        private void ModelName_Textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (ModelName_Textbox.Text.Length == 0)
            {
                if (e.Key == Key.Space)
                {
                    e.Handled = true;
                }
                flag2 = true;
            }
            else if (e.Key == Key.Space)
            {
                if (flag2)
                {
                    flag2 = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
