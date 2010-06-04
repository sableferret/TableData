using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Factory for IDataView items 
    /// </summary>    
    public class DataProvider : IDataProvider
    {
        #region Instance Members
        private readonly Dictionary<string, ITableView> views = new Dictionary<string, ITableView>();
        #endregion

        #region Constructor
        public DataProvider()
        {
            RowRepository = new ConstituentRowRepository();
        }
        #endregion

        #region Implementation of IDataProvider
        /// <summary>
        /// Create a new view of data
        /// </summary>
        /// <param name="query">Row Query</param>
        /// <param name="name">Friendly name</param>
        /// <param name="throttleTime">Minimum delay in milliseconds</param>
        /// <returns>New table view</returns>
        public ITableView CreateView(ITableQuery query, string name, int throttleTime)
        {
            return CreateView(query, name, null, throttleTime);
        }

        /// <summary>
        /// Create a view with a predetermined set of of columns
        /// </summary>
        /// <param name="query">Row Query</param>
        /// <param name="name">Friendly name</param>
        /// <param name="columns">Set of columns</param>
        /// <param name="throttleTime">Minimum delay in milliseconds</param>
        /// <returns>New table view</returns>
        public ITableView CreateView(ITableQuery query, string name, IList<IColumn> columns, int throttleTime)
        {
            ITableView view;
            if (views.TryGetValue(name, out view)) return view;

            view = new TableView(query, name, columns, throttleTime, RowRepository);
            views.Add(name, view);

            return view;
        }

        /// <summary>
        /// Return set of existing views 
        /// </summary>
        public IEnumerable<ITableView> Views { get { return views.Values; } }

        /// <summary>
        /// Return a view from its name
        /// </summary>
        /// <param name="name">name to index</param>
        /// <returns>Table view or null</returns>
        public ITableView this[string name] 
        {
            get
            {
                ITableView view;
                if (views.TryGetValue(name, out view)) return view;

                return null;
            }
        }

        /// <summary>
        /// Collection of all rows as a union result of all views
        /// </summary>
        public IConstituentRowRepository RowRepository { get; private set; }

        #endregion

        #region Implementation of IDisposable
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
