using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Service to pull data from a data source to satisfy the requirements of a table
    /// </summary>
    public interface IReadService : IDisposable
    {
        /// <summary>
        /// Subscribe for all content against a given row key
        /// </summary>
        /// <param name="rowKey">Row key to index on</param>
        /// <returns>Observable value representing the subscription</returns>
        IObservable<IConstituentRow> Subscribe(object rowKey);

        /// <summary>
        /// Subscribe to a specific set of columns/fields for a given row key
        /// </summary>
        /// <param name="rowKey">Row key to index on</param>
        /// <param name="columns">Set of columns to subscribe to</param>
        /// <returns>Observable value representing the subscription</returns>
        IObservable<IConstituentRow> Subscribe(object rowKey, IEnumerable<IColumn> columns);
    }
}
