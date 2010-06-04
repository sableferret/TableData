using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents a specific view onto a common data source
    /// </summary>
    public class TableView : ITableView
    {
        #region Instance Members
        private readonly int throttleTime;
        private readonly Dictionary<ITable, int> referenceCountedTables = new Dictionary<ITable, int>();
        #endregion

        #region Constructor
        public TableView(ITableQuery query, string name, IEnumerable<IColumn> columns, int throttleTime, IConstituentRowRepository currentRows)
        {
            #region Guards
            if (query == null) throw new ArgumentNullException("query", "query cannot be null");
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name", "name cannot be null or empty");
            #endregion

            TableQuery = query;
            Name = name;
            this.throttleTime = throttleTime;

            Columns = new ObservableCollection<IColumn>();
            ((ObservableCollection<IColumn>)Columns).CollectionChanged += OnColumnsChanged;

            if (columns != null)
                foreach (var column in columns)
                    Columns.Add(column);

            Data = new RowBinding(Columns, currentRows.AttachView(this));
        }

        #endregion

        #region Implementation of ITableView
        /// <summary>
        /// Method for returning row keys
        /// </summary>
        public ITableQuery TableQuery { get; private set; }

        /// <summary>
        /// Unique name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Set of composing columns
        /// </summary>
        public IList<IColumn> Columns { get; private set; }

        /// <summary>
        /// Binding point for data
        /// </summary>
        public IRowBinding Data { get; private set; }
        #endregion

        #region Column Change Notification
        void OnColumnsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (var item in e.NewItems.Cast<IColumn>())
                        {
                            int refCount;
                            referenceCountedTables.TryGetValue(item.Table, out refCount);
                            referenceCountedTables[item.Table] = ++refCount;
                        }
                    }
                    break;
            }
        }
        #endregion

        #region Implementation of IDisposable
        public void Dispose()
        {
        }
        #endregion
    }
}
