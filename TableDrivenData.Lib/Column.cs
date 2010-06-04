using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Provide an immutable column definition
    /// </summary>
    public class Column : IColumn
    {
        #region Instance Members
        private readonly int hashCode;
        #endregion

        #region Constructor
        public Column(ITable table, string name, Type type, 
                    [Optional, DefaultParameterValue(false)] bool canWrite,
                    [Optional, DefaultParameterValue(null)] string description,
                    [Optional, DefaultParameterValue(null)] string defaultFormatString,
                    [Optional, DefaultParameterValue(null)] Func<object, bool> validationMethod)
        {
            #region Guards
            if (table == null) throw new ArgumentNullException("table", "table cannot be null");
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name", "name cannot be null or empty");
            if (type == null) throw new ArgumentNullException("type", "type cannot be null");
            #endregion

            Table = table;
            Name = name;
            Key = string.Format("{0}_{1}", table.Name, name);
            Type = type;

            IsWritable = canWrite;
            Description = description;
            DefaultFormatString = defaultFormatString;
            ValidationMethod = validationMethod;

            hashCode = Table.GetHashCode() ^ Name.GetHashCode();
        }
        #endregion

        #region Properties
        public ITable Table
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Key
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public Type Type
        {
            get;
            private set;
        }

        public string DefaultFormatString
        {
            get;
            private set;
        }

        public bool IsWritable
        {
            get;
            private set;
        }

        public Func<object, bool> ValidationMethod
        {
            get;
            private set;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            var that = obj as Column;
            if (that == null) return false;

            return Name.Equals(that.Name) && Table.Equals(that.Table);
        }

        public override int GetHashCode()
        {
            return hashCode;
        }

        public override string ToString()
        {
            return Key;
        }
        #endregion
    }
}
