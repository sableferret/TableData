using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace NickField.TableDrivenData.Lib.IOServices
{
    [Export(typeof(IReadService))]
    public class BasicPublishingService : IReadService
    {
        #region Instance Members
        private readonly Dictionary<object, IObservable<IConstituentRow>> singleTableSubjects = new Dictionary<object, IObservable<IConstituentRow>>();
        private readonly HashSet<ITable> subscribedTables = new HashSet<ITable>();
        #endregion

        /// <summary>
        /// Subscribe for all content against a given row key
        /// </summary>
        /// <param name="rowKey">Row key to index on</param>
        /// <returns>Observable value representing the subscription</returns>
        public IObservable<IConstituentRow> Subscribe(object rowKey)
        {
            IObservable<IConstituentRow> subject;
            if (!singleTableSubjects.TryGetValue(rowKey, out subject))
            {
                subject = new BehaviorSubject<IConstituentRow>(null);
                singleTableSubjects.Add(rowKey, subject);
            }

            return subject;
        }

        /// <summary>
        /// Subscribe to a specific set of columns/fields for a given row key
        /// </summary>
        /// <param name="rowKey">Row key to index on</param>
        /// <param name="columns">Set of columns to subscribe to</param>
        /// <returns>Observable value representing the subscription</returns>
        public IObservable<IConstituentRow> Subscribe(object rowKey, IEnumerable<IColumn> columns)
        {
            var compositeSubscription = new CompositeSubscription(columns);
            foreach (var table in columns.Select(c => c.Table).Distinct())
                compositeSubscription.AddTable(table, Subscribe(rowKey));

            return compositeSubscription;
        }

        /// <summary>
        /// Remove all current subscription from the provider
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
