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
    public class HeadquarterInit : IDataInit<Headquarters>
    {
        private readonly IDataConnect _dbConnect;

        public HeadquarterInit(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public ObservableCollection<Headquarters>? DataInitialization()
        {
            var result = _dbConnect.DataGet("Headquarter").Result;

            if (!String.IsNullOrEmpty(result))
            {
                var content = JsonConvert.DeserializeObject<ObservableCollection<Headquarters>>(result);
                return content;
            }

            return null;
        }
    }
}
