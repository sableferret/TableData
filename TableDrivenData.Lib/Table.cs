using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Provide an immutable table definition
    /// </summary>
    public class Table : ITable
    {
        #region Constructor
        public Table(string name, IReadService readService)
        {
            #region Guards
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name", "name cannot be null or empty");
            if (readService == null) throw new ArgumentNullException("readService", "readService cannot be null");
            #endregion

            Name = name;
            ReadService = readService;
        }
        #endregion

        #region Properties
        public string Name
        {
            get;
            private set;
        }

        public IReadService ReadService
        {
            get;
            private set;
        }
        #endregion
    }
}
