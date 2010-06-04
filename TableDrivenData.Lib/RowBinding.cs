using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Binding point for collections of composite row data
    /// </summary>    
    public class RowBinding : ObservableCollection<IRowData>, IRowBinding
    {
        #region Instance Members
        private readonly IDictionary<object, IDictionary<ITable, IConstituentRow>> keyedConstituentRows; 
        private readonly PropertyDescriptorCollection descriptors;
        #endregion

        #region Constructor
        public RowBinding(IEnumerable<IColumn> columns, IEnumerable<IConstituentRow> cachedRows)
        {
            #region Guards
            if (columns == null) throw new ArgumentNullException("columns", "columns cannot be null");
            #endregion

            #region Column Descriptors
            var properties = columns.Select(c=>new TableColumnDescriptor(c)).ToArray();
            descriptors = new PropertyDescriptorCollection(properties);
            #endregion

            keyedConstituentRows = new Dictionary<object, IDictionary<ITable, IConstituentRow>>();
            if (cachedRows != null)
                foreach (var cachedRow in cachedRows)
                    AddConsituentRow(cachedRow);
        }
        #endregion

        #region Implementation of IBindingList
        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public object AddNew()
        {
            throw new NotImplementedException();
        }

        public bool AllowEdit
        {
            get { return true; }
        }

        public bool AllowNew
        {
            get { return false; }
        }

        public bool AllowRemove
        {
            get { return false; }
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted
        {
            get { throw new NotImplementedException(); }
        }

        public event ListChangedEventHandler ListChanged = (s,e) => { };

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }

        public ListSortDirection SortDirection
        {
            get { throw new NotImplementedException(); }
        }

        public PropertyDescriptor SortProperty
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { return true; }
        }

        public bool SupportsSorting
        {
            get { return true; }
        }
#endregion

        #region Implemenation of ITypedList
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return descriptors;
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "RowBinding";
        }
        #endregion

        #region Constituent Row Management
        private void AddConsituentRow(IConstituentRow row)
        {
            IDictionary<ITable, IConstituentRow> tableRow;
            if (!keyedConstituentRows.TryGetValue(row.RowKey, out tableRow))
            {
                tableRow = new Dictionary<ITable, IConstituentRow>();
                keyedConstituentRows.Add(row.RowKey, tableRow);
            }
            tableRow[row.Table] = row;
        }
        #endregion
    }
}
