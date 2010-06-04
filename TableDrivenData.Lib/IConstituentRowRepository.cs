using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// A collection of source rows which represents the union of all active rows derived
    /// from a query
    /// </summary>
    public interface IConstituentRowRepository : IDictionary<ITable, ISubscribableTableData>
    {
        /// <summary>
        /// Get all rows for a specific key
        /// </summary>
        /// <param name="key">Row key to use</param>
        /// <returns>Enumeration of rows</returns>
        IEnumerable<IConstituentRow> GetRowsForKey(object key);

        /// <summary>
        /// Return a row within a particular type for a table
        /// </summary>
        /// <param name="key">Row Key</param>
        /// <param name="table">Source table</param>
        /// <returns>Common row or null</returns>
        IConstituentRow GetRowForTable(object key, ITable table);

        /// <summary>
        /// Return a set of rows for a given table
        /// </summary>
        /// <param name="table">Table to query</param>
        /// <returns>Set of rows</returns>
        IEnumerable<IConstituentRow> GetRowsForTable(ITable table);

        /// <summary>
        /// Attach a view to the current repository, returning all the current rows
        /// for the requested tables
        /// </summary>
        /// <param name="view">View to attach</param>
        /// <returns>Enumerable set of cached rows</returns>
        IEnumerable<IConstituentRow> AttachView(ITableView view);

        /// <summary>
        /// Remove a view from the current repository
        /// </summary>
        /// <param name="view">View to remove</param>
        void DetachView(ITableView view);
    }
}
