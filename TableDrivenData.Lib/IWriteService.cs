using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents a service capable of writing data back to a table source
    /// </summary>
    public interface IWriteService
    {
        /// <summary>
        /// Write a value back to the source data 
        /// </summary>
        /// <param name="row">Row data applies to</param>
        /// <param name="column">Column data applies to</param>
        /// <param name="value">Value to update</param>
        void Write(IRowData row, IColumn column, object value);
    }
}
