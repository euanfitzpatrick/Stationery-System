using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery_System.Class
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int ItemID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ItemQuantity { get; set; }
        public int EmployeeID { get; set; }
        public string TransactionType { get; set; }
        public string ItemName { get; set; }

        public static void AddTransaction(int itemID, DateTime dateOfTransaction, int itemQuantity, string transactionType, Employee employee = null)
        {
            Transaction transaction = TransactionManager.CreateTransaction(itemID, dateOfTransaction, itemQuantity, transactionType, employee);
            Transaction[] transactionArray = TransactionManager.Transactions;
            List<Transaction> transactions = transactionArray != null ? transactionArray.ToList() : new List<Transaction>();
            transactions.Add(transaction);
            TransactionManager.Transactions = transactions.ToArray();
        }
    }
}
