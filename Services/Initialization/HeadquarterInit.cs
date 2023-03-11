using DotAgro.Interfaces;
using DotAgro.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Services.Initialization
{
    public class HeadquarterInit : IDataInit<Headquarter>
    {
        private readonly IDataConnect _dbConnect;

        public HeadquarterInit(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public ObservableCollection<Headquarter>? DataInitialization()
        {
            var result = _dbConnect.DataGet("Headquarter").Result;

            if (!String.IsNullOrEmpty(result))
            {
                var content = JsonConvert.DeserializeObject<ObservableCollection<Headquarter>>(result);
                return content;
            }

            return null;
        }
    }
}
