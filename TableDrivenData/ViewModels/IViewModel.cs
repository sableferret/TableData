using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NickField.TableDrivenData.Lib;
using System.Collections.ObjectModel;

namespace NickField.TableDrivenData.Presentation.ViewModels
{
    public interface IViewModel : IDisposable
    {
        IRowBinding RowData { get; }
        ObservableCollection<IColumn> Columns { get; }
    }
}
