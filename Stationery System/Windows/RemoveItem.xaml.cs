using Stationery_System.Class;
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

namespace Stationery_System.Windows
{
    /// <summary>
    /// Interaction logic for RemoveItem.xaml
    /// </summary>
    public partial class RemoveItem : Window
    {
        MainWindow Window { get; set; }
        Item Item { get; set; }

        public RemoveItem()
        {
            InitializeComponent();
        }

        public RemoveItem(MainWindow window, Item item)
        {
            InitializeComponent();
            Window = window;
            Item = item;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TxtEmployeeName.Text) || TxtEmployeeName.Text.Contains(';'))
            {
                MessageBox.Show("Please enter a valid employee name.", "Invalid Entry");
            }
            else
            {
                Item[] itemsArray = ItemManager.Items;
                List<Item> items = itemsArray != null ? itemsArray.ToList() : new List<Item>();
                if (items.Any(x => x.ItemName == Item.ItemName))
                {
                    Item currentItem = items.First(x => x.ItemName == Item.ItemName);
                    currentItem.ItemQuantity -= 1;
                }
                ItemManager.Items = items.ToArray();
                Window.PopulateInventory(ItemManager.Items);
                Window.EmployeeUI.EmpMgr.AddEmployee(TxtEmployeeName.Text);
                Window.PopulateEmployees();
                Employee[] employees = EmployeeManager.Employees;
                Employee employee = employees.First(x => x.EmployeeName == TxtEmployeeName.Text);
                Transaction.AddTransaction(Item.ItemID, DateTime.Now, Item.ItemQuantity, "Remove", employee);
                Window.PopulateTransactions();
                Window.PopulateFinancialReport();
                Close();
            }
        }
    }
}
