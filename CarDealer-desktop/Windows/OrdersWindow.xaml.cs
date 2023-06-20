using CarDealer.UserControls;
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
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using WinForms = System.Windows.Forms;
using System.Globalization;
using CarDealer_desktop.Models;
using System.Diagnostics;

namespace CarDealer.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {        
        public Order currentOrder { get; set; }
        public static List<Order> DisplayOrders = new List<Order>();
        private bool isFlag { get; set; }
        private bool isLoading{ get; set; }
        public OrdersWindow(Equipment equipments, Buyer buyers)
        {
            InitializeComponent();
            DataContext = this;
            if(equipments != null || buyers != null)
            {          
                //new EditOrAddOrdersWindow(null, equipments, buyers).ShowDialog();
            }
            BrandOrders_Combobox.Items.Add("Все марки");
            foreach (Brand brand in CDContext.cdContext.Brands.ToList())
            {
                BrandOrders_Combobox.Items.Add(brand.Title);
            }
            ModelOrders_Combobox.Items.Add("Все модели");
            SortOrders_Combobox.Items.Add("Сначала старые");
            SortOrders_Combobox.Items.Add("Сначала новые");
            SortOrders_Combobox.SelectedIndex = 0;
            UpdateOrdersList();
        }

        private void UpdateOrdersList()
        {
            isLoading = true;
            OrderList_View.Items.Clear();
            if(CurrentUser.currentUser.UserRoleId < 3 )
            {
                DisplayOrders = CDContext.cdContext.Orders.ToList();
            }
            else
            {
                DisplayOrders = CDContext.cdContext.Orders.Where(O => O.Manager == CurrentUser.currentUser).ToList();
            }
            if(SortOrders_Combobox.SelectedIndex > -1)
            {
                switch(SortOrders_Combobox.SelectedIndex)
                {
                    case 0:
                        DisplayOrders = DisplayOrders.OrderBy(o => o.Date).ToList();
                        break;
                    case 1:
                        DisplayOrders = DisplayOrders.OrderByDescending(o => o.Date).ToList();
                        break;
                }
            }
            if(BrandOrders_Combobox.SelectedIndex > 0)
            {
                ModelOrders_Combobox.IsEnabled = true;
                DisplayOrders = DisplayOrders.Where(o => o.Equipment.Model.Brand.Title == BrandOrders_Combobox.SelectedItem).ToList();
                if (isFlag)
                {
                    ModelOrders_Combobox.Items.Clear();
                    ModelOrders_Combobox.Items.Add("Все модели");
                    ModelOrders_Combobox.SelectedIndex = 0;
                    foreach(Model model in CDContext.cdContext.Models.Where(m => m.Brand.Title == BrandOrders_Combobox.SelectedItem).ToList())
                    {
                        if (!ModelOrders_Combobox.Items.Contains(model.Title))
                        {
                            ModelOrders_Combobox.Items.Add(model.Title);
                        }
                    }
                    isFlag = false;
                }
                
            }
            else
            {
                ModelOrders_Combobox.IsEnabled = false;
                ModelOrders_Combobox.SelectedIndex = 0;
            }
            if (ModelOrders_Combobox.SelectedIndex > 0)
            {
                DisplayOrders = DisplayOrders.Where(o => o.Equipment.Model.Title == ModelOrders_Combobox.SelectedItem).ToList();
            }
            foreach(Order orders in DisplayOrders)
            {
                OrderList_View.Items.Add(new OrdersControl(orders) { Width = GetNormalWidth() });
            }
            if(DisplayOrders.Count == 0)
            {
                EmptyOrders_Label.Visibility = Visibility.Visible;
                currentOrder = null;
            }
            else
            {
                EmptyOrders_Label.Visibility = Visibility.Hidden;
            }
            isLoading = false;
        }

        private Double GetNormalWidth()
        {
            if (WindowState == WindowState.Maximized)
                return RenderSize.Width - 50;

            else
                return Width - 50;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (OrdersControl item in OrderList_View.Items)
            {
                item.Width = GetNormalWidth();
            }
        }

        private void AddEditOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            new EditOrAddOrdersWindow(null, null, null).ShowDialog();
            UpdateOrdersList();
        }

        private void OrderList_View_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order orders = ((OrdersControl)OrderList_View.SelectedItem).Orders;
            new EditOrAddOrdersWindow(orders, null, null).ShowDialog();
            UpdateOrdersList();
        }      

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private Word._Application aWord;
       
        
        private void PrintDoc_Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrder != null)
            {
                if(currentOrder.AvailableCar == null)
                {
                    MessageBox.Show("Автомобиль в наличии не назначен");
                    return;
                }
                WinForms.FolderBrowserDialog fbd = new WinForms.FolderBrowserDialog();
                if (fbd.ShowDialog() == WinForms.DialogResult.OK)
                {

                    aWord = new Word.Application();
                    string ptc = Directory.GetCurrentDirectory() + "\\WordPattern\\PTS.docx";
                    if (File.Exists(ptc))
                    {
                        Word._Document aDoc = GetDoc(ptc);
                        string filename = System.IO.Path.GetRandomFileName() + ".docx";
                        Random rnd = new Random();
                        CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
                        var ru = CultureInfo.CreateSpecificCulture("ru-RU");
                        var tags = new Dictionary<string, string>
                        {
                            {"<d>", DateTime.Now.Day.ToString() },
                            {"<month>", ru.DateTimeFormat.MonthGenitiveNames[DateTime.Now.Month - 1]},
                            {"<y", DateTime.Now.Year.ToString() },
                            {"<ManagerFIO>", string.Join(" ", CurrentUser.currentUser.LastName, CurrentUser.currentUser.FirstName, CurrentUser.currentUser.Patronymic) },
                            {"<Mpass,1>", CurrentUser.currentUser.Passport.ToString().Substring(0,4) },
                            {"<Mpass,2>", CurrentUser.currentUser.Passport.ToString().Substring(4) },
                            {"<Mbirthday>", CurrentUser.currentUser.Birthday.ToString() },
                            {"<Buyer>", string.Join(" ", currentOrder.Buyer.LastName, currentOrder.Buyer.FirstName, currentOrder.Buyer.Patronymic)},
                            {"<Bbirthday>", currentOrder.Buyer.Birthday.ToString() },
                            {"<address>", currentOrder.Buyer.Address},
                            {"<Maddress>", CurrentUser.currentUser.Address},
                            {"<Bpass,1>", currentOrder.Buyer.Passport.ToString().Substring(0,4) },
                            {"<Bpass,2>", currentOrder.Buyer.Passport.ToString().Substring(4) },
                            {"<Brand>", currentOrder.Equipment.Model.Brand.Title + ", " + currentOrder.Equipment.Model.Title},
                            {"<VIN>", currentOrder.AvailableCar.Vin},
                            {"<manufyear>", currentOrder.Equipment.TechnicalInformation.Yearofmanufacture },
                            {"<Color>", currentOrder.Equipment.TechnicalInformation.Color.Title},
                            {"<Cost>", currentOrder.Equipment.Cost.ToString("0,0", elGR) + " рублей"},
                            {"<Mphone>", currentOrder.Manager.Phone.ToString()},
                            {"<Bphone>", currentOrder.Buyer.Phone.ToString()},
                            {"<ManagerF>", $"{CurrentUser.currentUser.LastName} {CurrentUser.currentUser.FirstName[0]}. {CurrentUser.currentUser.Patronymic[0]}."},
                            {"<BuyerF>", $"{currentOrder.Buyer.LastName} {currentOrder.Buyer.FirstName[0]}. {currentOrder.Buyer.Patronymic[0]}."},
                        };
                        foreach (var tag in tags)
                        {
                            aWord.Selection.Find.Text = tag.Key;
                            aWord.Selection.Find.Replacement.Text = tag.Value;
                            Object wrap = Word.WdFindWrap.wdFindContinue;
                            Object replace = Word.WdReplace.wdReplaceAll;
                            aWord.Selection.Find.Execute(FindText: Type.Missing, MatchCase: false, Forward: true, Wrap: wrap, Replace: replace);
                        }
                        currentOrder.AvailableCar.CanOrder = 0;
                        CDContext.cdContext.SaveChanges();
                        string finalpath = fbd.SelectedPath + '/' + filename;
                        aDoc.SaveAs2(finalpath);
                        MessageBox.Show("Договор купли-продажи успешно создан!", "Уведомление");
                        aWord.Visible = true;
                        aDoc.Close();
                        aWord.Quit();
                        if(File.Exists(finalpath))
                            Process.Start(new ProcessStartInfo(finalpath) { UseShellExecute = true });
                    }
                    else
                    {
                        MessageBox.Show("Шаблон не найден");
                    }
                }
            }
            else
            {
                MessageBox.Show("Заказ не выбран", "Уведомление");
            }
        }

        private Word._Document GetDoc(string path)
        {
            Word._Document aDoc = aWord.Documents.Add(path);
            return aDoc;
        }

        private void OrderList_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(OrderList_View.SelectedItem != null)
            {
                Order orders = ((OrdersControl)OrderList_View.SelectedItem).Orders;
                currentOrder = orders;
            }
        }

        private void SortOrders_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrdersList();
        }

        private void BrandOrders_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            isFlag = true;
            UpdateOrdersList();            
        }

        private void ModelOrders_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
            if(!isFlag)
                UpdateOrdersList();                    
        }
    }
}
