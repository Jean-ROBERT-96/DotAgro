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
    public class HeadquarterManage : IDataManage<Headquarters>
    {
        private readonly IDataConnect _dbConnect;
        private const string type = "Headquarter";

        public HeadquarterManage(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public ObservableCollection<Headquarters>? GetData()
        {
            var result = _dbConnect.DataGet(type).Result;

            if (!String.IsNullOrEmpty(result))
            {
                var content = JsonConvert.DeserializeObject<ObservableCollection<Headquarters>>(result);
                return content;
            }

            return null;
        }

        public bool AddData(Headquarters item)
        {
            if (_dbConnect.DataPost(item, type).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool DeleteData(Headquarters item)
        {
            if (_dbConnect.DataDelete(type, item.Id).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool EditData(Headquarters item)
        {
            if (_dbConnect.DataPut(item, $"{type}/{item.Id}").IsCompletedSuccessfully)
                return true;

            return false;
        }
    }
}
