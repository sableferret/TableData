using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    public class ConstituentRowRepository : Dictionary<ITable, ISubscribableTableData>, IConstituentRowRepository
    {
        #region Implementation of IConsituentRowRepository
        /// <summary>
        /// Get all rows for a specific key
        /// </summary>
        /// <param name="key">Row key to use</param>
        /// <returns>Enumeration of rows</returns>
        public IEnumerable<IConstituentRow> GetRowsForKey(object key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a row within a particular type for a table
        /// </summary>
        /// <param name="key">Row Key</param>
        /// <param name="table">Source table</param>
        /// <returns>Common row or null</returns>
        public IConstituentRow GetRowForTable(object key, ITable table)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a set of rows for a given table
        /// </summary>
        /// <param name="table">Table to query</param>
        /// <returns>Set of rows</returns>
        public IEnumerable<IConstituentRow> GetRowsForTable(ITable table)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attach a view to the current repository, returning all the current rows
        /// for the requested tables
        /// </summary>
        /// <param name="view">View to attach</param>
        /// <returns>Enumerable set of cached rows</returns>
        public IEnumerable<IConstituentRow> AttachView(ITableView view)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove a view from the current repository
        /// </summary>
        /// <param name="view">View to remove</param>
        public void DetachView(ITableView view)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
