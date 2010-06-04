using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents a method of returning row keys for table subscription
    /// </summary>
    public interface ITableQuery 
    {
        /// <summary>
        /// Make naked query to the underlying data source returning an IObservable
        /// collection of row keys
        /// </summary>
        /// <returns></returns>
        IObservable<object> Query();
    }
}
