using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents a specific view onto a common data source
    /// </summary>
    public interface ITableView : IDisposable
    {
        /// <summary>
        /// Unique name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Set of composing columns
        /// </summary>
        IList<IColumn> Columns { get; }

        /// <summary>
        /// Binding point for data
        /// </summary>
        IRowBinding Data { get; }

        /// <summary>
        /// Method for returning row keys
        /// </summary>
        ITableQuery TableQuery { get; }
    }
}
