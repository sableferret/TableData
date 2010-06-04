using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// "Live" set of rows for a single table. This is a multi-cast point for introducing
    /// a set of rows to a view
    /// </summary>
    public interface ISubscribableTableData : IEnumerable<IRowData>, IDisposable
    {
        /// <summary>
        /// Table representing the logical source of the data
        /// </summary>
        ITable Table { get; }

        /// <summary>
        /// Attach a listener to the current set of listeners for this table
        /// </summary>
        /// <param name="view">view to attach</param>
        /// <returns>Current cached rows</returns>
        IObservable<IConstituentRow> AttachTableView(ITableView view);

        /// <summary>
        /// Detach a tableview from this current set of rows
        /// </summary>
        /// <param name="view">view to detach</param>
        void DetachTableView(ITableView view);
    }
}
