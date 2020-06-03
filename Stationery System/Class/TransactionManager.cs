using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery_System.Class
{
    public class TransactionManager
    {
        public static Transaction[] Transactions
        {
            get
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Transactions.csv";
                if (!File.Exists(path)) return null;
                List<Transaction> transactions = new List<Transaction>();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    Transaction transaction = new Transaction();
                    string[] parts = line.Split(';');
                    transaction.TransactionID = int.Parse(parts[0]);
                    transaction.TransactionDate = DateTime.Parse(parts[1]);
                    transaction.ItemID = int.Parse(parts[2]);
                    transaction.ItemQuantity = int.Parse(parts[3]);
                    transaction.EmployeeID = int.Parse(parts[4]);
                    transaction.TransactionType = parts[5];
                    transaction.ItemName = parts[6];
                    transactions.Add(transaction);
                }
                return transactions.ToArray();
            }
            set
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Transactions.csv";
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Transaction t in value)
                {
                    string date = t.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string line = $"{t.TransactionID};{date};{t.ItemID};{t.ItemQuantity};{t.EmployeeID};{t.TransactionType};{t.ItemName}";
                    stringBuilder.AppendLine(line);
                }
                File.WriteAllText(path, stringBuilder.ToString());
            }
        }

        public static Transaction CreateTransaction(int itemID, DateTime dateOfTransaction, int itemQuantity, string transactionType, Employee employee = null)
        {
            Transaction[] transactions = Transactions;
            int nextID = 1;
            if (transactions != null && transactions.Any())
            {
                nextID = transactions.OrderBy(x => x.TransactionID).Last().TransactionID + 1;
            }
            Transaction transaction = new Transaction();
            transaction.TransactionID = nextID;
            transaction.TransactionDate = dateOfTransaction;
            transaction.ItemID = itemID;
            transaction.ItemQuantity = itemQuantity;
            transaction.EmployeeID = employee != null ? employee.EmployeeID : 0;
            transaction.TransactionType = transactionType;
            transaction.ItemName = ItemManager.Items.First(x => x.ItemID == itemID).ItemName;
            return transaction;
        }

        public Transaction[] GetTransactionLog()
        {
            return Transactions;
        }

        public Transaction[] ReportPersonalUsage(Employee employee)
        {
            return Transactions.Where(x => x.EmployeeID == employee.EmployeeID).ToArray();
        }
    }
}
