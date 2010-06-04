using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Binding point for collections of composite row data
    /// </summary>
    public interface IRowBinding : IList<IRowData>, IBindingList, ITypedList
    {
    }
}
