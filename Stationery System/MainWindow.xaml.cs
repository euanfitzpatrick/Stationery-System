using Stationery_System.Class;
using Stationery_System.UserControls;
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

namespace Stationery_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EmployeeUI EmployeeUI { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            EmployeeUI = new EmployeeUI(new TransactionManager(), new ItemManager(), new EmployeeManager());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Item[] items = ItemManager.Items;
            if (items != null && items.Any())
            {
                PopulateInventory(items);
            }
            PopulateEmployees();
            PopulateTransactions();
            PopulateFinancialReport();
        }

        public void PopulateInventory(Item[] items)
        {
            GrdInventory.Children.Clear();
            GrdInventory.RowDefinitions.Clear();
            int s = 0;
            for (int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                if (item.ItemQuantity <= 0) continue;
                ItemUserControl itemUserControl = new ItemUserControl(item, this);
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(50, GridUnitType.Pixel);
                GrdInventory.RowDefinitions.Add(rowDefinition);
                GrdInventory.Children.Add(itemUserControl);
                Grid.SetRow(itemUserControl, s);
                s++;
            }
        }

        public void PopulateEmployees()
        {
            Employee[] employees = EmployeeManager.Employees;
            CboEmployee.Items.Clear();
            if (employees == null) return;
            for (int i = 0; i < employees.Length; i++)
            {
                Employee employee = employees[i];
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = employee.EmployeeName;
                cbi.Tag = employee;
                CboEmployee.Items.Add(cbi);
            }
        }

        public void PopulateTransactions()
        {
            GrdTransactions.Children.Clear();
            GrdTransactions.RowDefinitions.Clear();
            Transaction[] transactions = TransactionManager.Transactions;
            if (transactions == null) return;
            for (int i = 0; i < transactions.Length; i++)
            {
                Transaction transaction = transactions[i];
                TransactionUserControl control = new TransactionUserControl(transaction);
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(50, GridUnitType.Pixel);
                GrdTransactions.RowDefinitions.Add(rowDefinition);
                GrdTransactions.Children.Add(control);
                Grid.SetRow(control, i);
            }
        }

        public void PopulateFinancialReport()
        {
            Item[] items = ItemManager.Items;
            GrdFinancialReport.Children.Clear();
            GrdFinancialReport.RowDefinitions.Clear();
            if (items == null || !items.Any()) return;
            decimal total = 0;
            foreach (Item item in items)
            {
                total += item.ItemPrice * item.ItemQuantity;
            }
            string totalStr = total.ToString("0.00");
            LblTotalExpenditure.Content = $"Total Expenditure: £{totalStr}";
            int s = 0;
            for (int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                if (item.ItemQuantity <= 0) continue;
                FinancialReportUserControl control = new FinancialReportUserControl(item);
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(50, GridUnitType.Pixel);
                GrdFinancialReport.RowDefinitions.Add(rowDefinition);
                GrdFinancialReport.Children.Add(control);
                Grid.SetRow(control, s);
                s++;
            }
        }

        private void BtnAddStock_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(EmployeeUI, this);
            addItemWindow.Topmost = true;
            addItemWindow.Show();
        }

        private void BtnSearchEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (CboEmployee.SelectedIndex < 0) return;
            ComboBoxItem cbi = CboEmployee.SelectedItem as ComboBoxItem;
            Employee employee = cbi.Tag as Employee;
            Transaction[] transactions = TransactionManager.Transactions.Where(x => x.EmployeeID == employee.EmployeeID).ToArray();
            GrdEmployeeUsage.Children.Clear();
            GrdEmployeeUsage.RowDefinitions.Clear();
            if (transactions == null || !transactions.Any()) return;
            for (int i = 0; i < transactions.Length; i++)
            {
                Transaction transaction = transactions[i];
                EmployeeUsageUserControl control = new EmployeeUsageUserControl(transaction);
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(50, GridUnitType.Pixel);
                GrdEmployeeUsage.RowDefinitions.Add(rowDefinition);
                GrdEmployeeUsage.Children.Add(control);
                Grid.SetRow(control, i);
            }
        }
    }
}
