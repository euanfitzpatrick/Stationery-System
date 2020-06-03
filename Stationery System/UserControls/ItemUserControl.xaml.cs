using Stationery_System.Class;
using Stationery_System.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stationery_System.UserControls
{
    /// <summary>
    /// Interaction logic for ItemUserControl.xaml
    /// </summary>
    public partial class ItemUserControl : UserControl
    {
        private Item Item { get; set; }
        private MainWindow Window { get; set; }

        public ItemUserControl(Item item, MainWindow window)
        {
            InitializeComponent();
            Item = item;
            Window = window;
            LblItemID.Content = item.ItemID.ToString();
            LblItemName.Content = item.ItemName;
            LblItemPrice.Content = item.ItemPrice.ToString("0.00");
            LblItemQuantity.Content = item.ItemQuantity.ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Window.EmployeeUI.ItemMgr.AddItem(Item.ItemName, Item.ItemPrice);
            Window.PopulateInventory(ItemManager.Items);
        }

        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem removeItem = new RemoveItem(Window, Item);
            removeItem.Topmost = true;
            removeItem.Show();
        }
    }
}
