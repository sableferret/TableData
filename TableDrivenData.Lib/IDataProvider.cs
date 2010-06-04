using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// MEF
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Factory for IDataView items 
    /// </summary>
    public interface IDataProvider : IDisposable
    {
        /// <summary>
        /// Create a new view of data
        /// </summary>
        /// <param name="query">Row Query</param>
        /// <param name="name">Friendly name</param>
        /// <param name="throttleTime">Minimum delay in milliseconds</param>
        /// <returns>New table view</returns>
        ITableView CreateView(ITableQuery query, string name, int throttleTime);

        /// <summary>
        /// Create a view with a predetermined set of of columns
        /// </summary>
        /// <param name="query">Row Query</param>
        /// <param name="name">Friendly name</param>
        /// <param name="columns">Set of columns</param>
        /// <param name="throttleTime">Minimum delay in milliseconds</param>
        /// <returns>New table view</returns>
        ITableView CreateView(ITableQuery query, string name, IList<IColumn> columns, int throttleTime);

        /// <summary>
        /// Return set of existing views 
        /// </summary>
        IEnumerable<ITableView> Views { get; }

        /// <summary>
        /// Return a view from its name
        /// </summary>
        /// <param name="name">name to index</param>
        /// <returns>Table view or null</returns>
        ITableView this[string name] { get; }

        /// <summary>
        /// Collection of all rows as a union result of all views
        /// </summary>
        IConstituentRowRepository RowRepository { get; }
    }
}
