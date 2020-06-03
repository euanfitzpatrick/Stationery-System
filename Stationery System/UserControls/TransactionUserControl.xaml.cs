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
    /// Interaction logic for TransactionUserControl.xaml
    /// </summary>
    public partial class TransactionUserControl : UserControl
    {
        public TransactionUserControl()
        {
            InitializeComponent();
        }

        public TransactionUserControl(Transaction transaction)
        {
            InitializeComponent();
            Item item = ItemManager.Items.First(x => x.ItemID == transaction.ItemID);
            Employee employee = new Employee();
            if (transaction.TransactionType == "Remove")
            {
                employee = EmployeeManager.Employees.First(x => x.EmployeeID == transaction.EmployeeID);
            }
            LblTransactionID.Content = transaction.TransactionID.ToString();
            LblTransactionType.Content = transaction.TransactionType;
            LblItemID.Content = transaction.ItemID.ToString();
            LblItemName.Content = transaction.ItemName;
            LblItemPrice.Content = transaction.TransactionType == "Add" ? item.ItemPrice.ToString("0.00") : "--";
            LblEmployee.Content = transaction.TransactionType == "Add" ? "--" : employee.EmployeeName;
            LblDateTime.Content = transaction.TransactionDate.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
