using DotAgro.Interfaces;
using DotAgro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Services.Management
{
    public class SalaryManage : IDataManage<Salary>
    {
        private readonly IDataConnect _dbConnect;

        public SalaryManage(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public bool AddData(Salary item)
        {
            if (_dbConnect.DataPost(item, "Salary").IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool DeleteData(Salary item)
        {
            if (_dbConnect.DataDelete("Salary", item.Id).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool EditData(Salary item)
        {
            if (_dbConnect.DataPut(item, "Salary").IsCompletedSuccessfully)
                return true;

            return false;
        }
    }
}
