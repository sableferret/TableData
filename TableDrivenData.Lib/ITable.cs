using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents a logical source of data rows and columns
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// Unique name (within the provider)
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Subscription/Data access service
        /// </summary>
        IReadService ReadService { get; }
    }
}
