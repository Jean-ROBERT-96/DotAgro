using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Interfaces
{
    public interface IDataConnect
    {
        Task<string?> DataGet(string args);
        Task<string> DataPost(object item, string args);
        Task<string> DataPut(object item, string args);
        Task<string> DataDelete(int id);
    }
}
