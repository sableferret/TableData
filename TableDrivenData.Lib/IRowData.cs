using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Container of IConstituentRow items leading to a consolidated data row
    /// </summary>
    public interface IRowData : ICustomTypeDescriptor, INotifyPropertyChanged
    {
        /// <summary>
        /// Unique Row Key
        /// </summary>
        object RowKey { get; }

        /// <summary>
        /// Source rows which hold the actual data
        /// </summary>
        IDictionary<ITable, IConstituentRow> ConstituentRows { get; }

        /// <summary>
        /// Return the data value for a given column
        /// </summary>
        /// <param name="column">Source column to lookup</param>
        /// <returns>cell value of default for column type</returns>
        object GetCellData(IColumn column);
    }
}
