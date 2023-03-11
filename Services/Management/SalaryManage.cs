using DotAgro.Interfaces;
using DotAgro.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Services.Management
{
    public class SalaryManage : IDataManage<Salary>
    {
        private readonly IDataConnect _dbConnect;
        private const string type = "Salary";

        public SalaryManage(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public ObservableCollection<Salary>? GetData()
        {
            var result = _dbConnect.DataGet(type).Result;

            if (!String.IsNullOrEmpty(result))
            {
                var content = JsonConvert.DeserializeObject<ObservableCollection<Salary>>(result);
                return content;
            }

            return null;
        }

        public bool AddData(Salary item)
        {
            if (_dbConnect.DataPost(item, type).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool DeleteData(Salary item)
        {
            if (_dbConnect.DataDelete(type, item.Id).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool EditData(Salary item)
        {
            if (_dbConnect.DataPut(item, type).IsCompletedSuccessfully)
                return true;

            return false;
        }
    }
}
