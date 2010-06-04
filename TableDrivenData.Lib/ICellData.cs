using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents data for a single cell
    /// </summary>
    public interface ICellData : INotifyPropertyChanged
    {
        /// <summary>
        /// Column this value refers to
        /// </summary>
        IColumn Column { get; }
 
        /// <summary>
        /// Current value of the cell
        /// </summary>
        object Value { get; }
    }
}
