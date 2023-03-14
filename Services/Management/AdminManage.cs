using DotAgro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Services.Management
{
    public class AdminManage : IDataAdmin
    {
        private readonly IDataConnect _dbConnect;
        private const string type = "Admin";

        public AdminManage(IDataConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public bool AdminConnect(string mail, string password)
        {
            var result = _dbConnect.DataGet($"{type}/{mail}/{password}").Result;

            return Convert.ToBoolean(result);
        }
    }
}
