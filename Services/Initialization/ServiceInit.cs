using DotAgro.Models;
using DotAgro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace DotAgro.Services.Initialization
{
    public class ServiceInit : IDataInit<Models.Services>
    {
        private readonly IDataConnect _dbConnect;

        public ServiceInit(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public ObservableCollection<Models.Services>? DataInitialization()
        {
            var result = _dbConnect.DataGet("Service").Result;

            if (!String.IsNullOrEmpty(result))
            {
                var content = JsonConvert.DeserializeObject<ObservableCollection<Models.Services>>(result);
                return content;
            }

            return null;
        }
    }
}
