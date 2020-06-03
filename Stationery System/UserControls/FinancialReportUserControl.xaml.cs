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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stationery_System.UserControls
{
    /// <summary>
    /// Interaction logic for FinancialReportUserControl.xaml
    /// </summary>
    public partial class FinancialReportUserControl : UserControl
    {
        public FinancialReportUserControl(Item item)
        {
            InitializeComponent();
            LblItemID.Content = item.ItemID.ToString();
            LblItemName.Content = item.ItemName;
            LblItemTotalExpenditure.Content = (item.ItemPrice * item.ItemQuantity).ToString("0.00");
        }
    }
}
