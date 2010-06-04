using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NickField.TableDrivenData.Lib;
using System.Collections.ObjectModel;
using NickField.TableDrivenData.Lib.IOServices;

namespace NickField.TableDrivenData.Presentation.ViewModels
{
    public class ViewModel : IViewModel
    {
        #region Instance Members
        private readonly ITableView view;
        #endregion

        public ViewModel(IDataProvider dataProvider, IList<IColumn> columns)
        {
            view = dataProvider.CreateView(new SimpleRowQuery(), "test", columns, 0);
            RowData = view.Data;
        }

        public IRowBinding RowData
        {
            get;
            private set;
        }

        public ObservableCollection<IColumn> Columns
        {
            get;
            private set;
        }

        #region Implementation of IDisposable
        public void Dispose()
        {
            view.Dispose();
        }
        #endregion
    }
}
