using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Interfaces
{
    public interface IDataManage<T>
    {
        bool AddData(T item);
        bool EditData(T item);
        bool DeleteData(T item);
    }
}
