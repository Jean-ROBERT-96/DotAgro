using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.entity
{
    public class Services
    {
        public int id_service { get; init; }
        public string name { get; set; }

        public Services(int id_service, string name)
        {
            this.id_service = id_service;
            this.name = name;
        }
    }
}
