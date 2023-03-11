using DotAgro.Models;
using DotAgro.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Services.Initialization
{
    public class SalaryInit : IDataInit<Salary>
    {
        private readonly IDataConnect _dbConnect;

        public SalaryInit(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public ObservableCollection<Salary>? DataInitialization()
        {
            var result = _dbConnect.DataGet("Salary").Result;

            if(!String.IsNullOrEmpty(result))
            {
                var content = JsonConvert.DeserializeObject<ObservableCollection<Salary>>(result);
                return content;
            }

            return null;
        }
    }
}
