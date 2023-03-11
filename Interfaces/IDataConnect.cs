using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Interfaces
{
    public interface IDataConnect
    {
        Task<string?> DataGet(string args);
        Task<HttpResponseMessage> DataPost(object item, string args);
        Task<HttpResponseMessage> DataPut(object item, string args);
        Task<HttpResponseMessage> DataDelete(string args, int id);
    }
}
