using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Represents a multi-table subscription and provides an aggregated publication
    /// </summary>
    public class CompositeSubscription : IObservable<IConstituentRow>
    {
        private readonly IEnumerable<IColumn> columns;

        public CompositeSubscription(IEnumerable<IColumn> columns)
        {
            this.columns = columns;
        }

        public void AddTable(ITable table, IObservable<IConstituentRow> iObservable)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<IConstituentRow> observer)
        {
            throw new NotImplementedException();
        }
    }
}
