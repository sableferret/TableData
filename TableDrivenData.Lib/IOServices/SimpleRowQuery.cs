using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickField.TableDrivenData.Lib.IOServices
{
    public class SimpleRowQuery : ITableQuery
    {
        private const int RowCount = 100;

        /// <summary>
        /// Make naked query to the underlying data source returning an IObservable
        /// collection of row keys
        /// </summary>
        /// <returns></returns>
        public IObservable<object> Query()
        {
            throw new NotImplementedException();
        }

    }
}
