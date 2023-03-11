using DotAgro.Interfaces;
using DotAgro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Services.Management
{
    public class ServiceManage : IDataManage<Models.Services>
    {
        private readonly IDataConnect _dbConnect;

        public ServiceManage(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public bool AddData(Models.Services item)
        {
            if (_dbConnect.DataPost(item, "Service").IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool DeleteData(Models.Services item)
        {
            if (_dbConnect.DataDelete("Service", item.Id).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool EditData(Models.Services item)
        {
            if (_dbConnect.DataPut(item, "Service").IsCompletedSuccessfully)
                return true;

            return false;
        }
    }
}
