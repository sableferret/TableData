using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// A qualified column with originating source, unique name and formatting information
    /// </summary>
    public interface IColumn
    {
        /// <summary>
        /// Source table from which data is derived
        /// </summary>
        ITable Table { get; }

        /// <summary>
        /// Unique name of column within the table
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Amalgum of table and name
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Full description of the column
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Underlying data type for the column
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Any default formatting
        /// </summary>
        string DefaultFormatString { get; }

        /// <summary>
        /// Determines if the column data can be written back to
        /// </summary>
        bool IsWritable { get; }

        /// <summary>
        /// Validation delegate for writable data
        /// </summary>
        Func<object, bool> ValidationMethod { get; }
    }
}
