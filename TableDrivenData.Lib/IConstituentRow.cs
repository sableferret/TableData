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
    public interface IConstituentRow : INotifyPropertyChanged
    {
        /// <summary>
        /// Indexing value for the row
        /// </summary>
        object RowKey { get; }

        /// <summary>
        /// Table the row originated from
        /// </summary>
        ITable Table { get; }

        /// <summary>
        /// Collection of column data
        /// </summary>
        IDictionary<IColumn, ICellData> Cells { get; }

        /// <summary>
        /// Update the row in terms of its cells. This will fire a row changed
        /// event
        /// </summary>
        /// <param name="data">Collection of cell data indexed by column</param>
        void UpdateRow(IDictionary<IColumn, ICellData> data);
    }
}
