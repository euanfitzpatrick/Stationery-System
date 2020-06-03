using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery_System.Class
{
    public class EmployeeUI
    {
        public TransactionManager TranMgr { get; set; }
        public ItemManager ItemMgr { get; set; }
        public EmployeeManager EmpMgr { get; set; }

        public EmployeeUI(TransactionManager tranMgr, ItemManager itemMgr, EmployeeManager empMgr)
        {
            TranMgr = tranMgr;
            ItemMgr = itemMgr;
            EmpMgr = empMgr;
        }
    }
}
