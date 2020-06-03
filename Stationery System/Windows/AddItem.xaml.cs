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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        private EmployeeUI EmployeeUI { get; set; }
        private MainWindow Window { get; set; }

        public AddItem()
        {
            InitializeComponent();
        }

        public AddItem(EmployeeUI employeeUI, MainWindow window)
        {
            InitializeComponent();
            EmployeeUI = employeeUI;
            Window = window;
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            Item[] items = ItemManager.Items;
            if (String.IsNullOrWhiteSpace(TxtItemName.Text) || TxtItemName.Text.Contains(';'))
            {
                MessageBox.Show("Please enter the item name.", "Invalid Entry");
            }
            else if (items != null && items.Any(x => x.ItemName == TxtItemName.Text && x.ItemQuantity > 0))
            {
                MessageBox.Show("Item already exists.", "Invalid Entry");
            }
            else if (!decimal.TryParse(TxtItemPrice.Text, out decimal r1) || decimal.Parse(TxtItemPrice.Text) <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Invalid Entry");
            }
            else if (!int.TryParse(TxtItemQuantity.Text, out int r2) || int.Parse(TxtItemQuantity.Text) <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Entry");
            }
            else
            {
                for (int i = 0; i < r2; i++)
                {
                    EmployeeUI.ItemMgr.AddItem(TxtItemName.Text, r1);
                }
                Window.PopulateInventory(ItemManager.Items);
                Item item = ItemManager.Items.First(x => x.ItemName == TxtItemName.Text);
                Transaction.AddTransaction(item.ItemID, DateTime.Now, item.ItemQuantity, "Add");
                Window.PopulateTransactions();
                Window.PopulateFinancialReport();
                Close();
            }
        }
    }
}
