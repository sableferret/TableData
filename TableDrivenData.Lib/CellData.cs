using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Holds the value of a single cell (column for a given row key)
    /// </summary>
    public class CellData : ICellData
    {
        #region Instance Members
        private object cellValue;
        private readonly PropertyChangedEventArgs valueChangedArgs = new PropertyChangedEventArgs("Value");
        #endregion

        #region Constructor
        public CellData(IColumn column, object defaultValue)
        {
            #region Guards
            if (column == null) throw new ArgumentNullException("column", "column cannot be null");
            #endregion

            Column = column;
            Value = defaultValue;
        }
        #endregion

        #region Implementation of ICellData
        public IColumn Column
        {
            get;
            private set;
        }

        public object Value
        {
            get { return cellValue; }
            internal set
            {
                if (cellValue != value)
                {
                    cellValue = value;
                    PropertyChanged(this, valueChangedArgs);
                }
            }
        }
        #endregion

        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = (s,e) => { };
        #endregion
    }
}
