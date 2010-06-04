using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents a source row of data
    /// </summary>    
    public class ConstituentRow : IConstituentRow
    {
        #region InstanceMembers
        private readonly PropertyChangedEventArgs cellsChangedArgs = new PropertyChangedEventArgs("Cells");
        #endregion

        #region Constructor
        public ConstituentRow(object key, IDictionary<IColumn, ICellData> data)
        {
            #region Guards
            if (key == null) throw new ArgumentNullException("key", "key cannot be null");
            #endregion

            RowKey = key;

            Cells = new Dictionary<IColumn, ICellData>();
            UpdateRow(data);
        }
        #endregion

        #region Implementation of IConstituentRow
        public object RowKey
        {
            get;
            private set;
        }

        public ITable Table
        {
            get;
            private set;
        }

        public IDictionary<IColumn, ICellData> Cells
        {
            get;
            private set;
        }

        public void UpdateRow(IDictionary<IColumn, ICellData> data)
        {
            if (data != null)
            {
                foreach (var cellItem in data)
                    Cells[cellItem.Key] = cellItem.Value;

                PropertyChanged(this, cellsChangedArgs);
            }
        }

        #endregion

        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = (s,e) => { };
        #endregion
    }
}
