using DotAgro.Interfaces;
using DotAgro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Services.Management
{
    public class HeadquarterManage : IDataManage<Headquarters>
    {
        private readonly IDataConnect _dbConnect;

        public HeadquarterManage(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public bool AddData(Headquarters item)
        {
            if (_dbConnect.DataPost(item, "Headquarter").IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool DeleteData(Headquarters item)
        {
            if (_dbConnect.DataDelete("Headquarter", item.Id).IsCompletedSuccessfully)
                return true;

            return false;
        }

        public bool EditData(Headquarters item)
        {
            if (_dbConnect.DataPut(item, "Headquarter").IsCompletedSuccessfully)
                return true;

            return false;
        }
    }
}
