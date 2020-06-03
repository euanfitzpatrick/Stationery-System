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
    /// Interaction logic for EmployeeUsageUserControl.xaml
    /// </summary>
    public partial class EmployeeUsageUserControl : UserControl
    {
       public EmployeeUsageUserControl()
        {
            InitializeComponent();
        }

        public EmployeeUsageUserControl(Transaction transaction)
        {
            InitializeComponent();
            LblItemID.Content = transaction.ItemID.ToString();
            LblItemName.Content = transaction.ItemName;
            LblDateTime.Content = transaction.TransactionDate.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
