using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    public class SubscribableTableData : ISubscribableTableData
    {
        public SubscribableTableData(ITable table)
        {
            Table = table;
        }

        /// <summary>
        /// Table representing the logical source of the data
        /// </summary>
        public ITable Table
        {
            get;
            private set;
        }

        /// <summary>
        /// Attach a listener to the current set of listeners for this table
        /// </summary>
        /// <param name="view">view to attach</param>
        /// <returns>Current cached rows</returns>        
        public IObservable<IConstituentRow> AttachTableView(ITableView view)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Detach a tableview from this current set of rows
        /// </summary>
        /// <param name="view">view to detach</param>
        public void DetachTableView(ITableView view)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IRowData> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
