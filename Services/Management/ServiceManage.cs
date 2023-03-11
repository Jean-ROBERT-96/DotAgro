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
    public class ServiceManage : IDataManage<Models.Services>
    {
        private readonly IDataConnect _dbConnect;
        private const string type = "Services";

        public ServiceManage(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public ObservableCollection<Models.Services>? GetData()
        {
            var result = _dbConnect.DataGet(type).Result;

            if (!String.IsNullOrEmpty(result))
            {
                var content = JsonConvert.DeserializeObject<ObservableCollection<Models.Services>>(result);
                return content;
            }

            return null;
        }

        public bool AddData(Models.Services item)
        {
            if (_dbConnect.DataPost(item, type).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool DeleteData(Models.Services item)
        {
            if (_dbConnect.DataDelete(type, item.Id).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool EditData(Models.Services item)
        {
            if (_dbConnect.DataPut(item, type).IsCompletedSuccessfully)
                return true;

            return false;
        }
    }
}
