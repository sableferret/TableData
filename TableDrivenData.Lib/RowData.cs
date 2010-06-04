using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Container of IConstituentRow items leading to a consolidated data row
    /// </summary>   
    public class RowData : IRowData
    {
        #region Instance Members
        private readonly PropertyDescriptorCollection descriptors;
        private static AttributeCollection attributeCollection = new AttributeCollection(null);
        #endregion

        #region Constructor
        public RowData(object rowKey, PropertyDescriptorCollection descriptors)
        {
            #region Guards
            if (rowKey == null) throw new ArgumentNullException("rowKey", "rowKey cannot be null");
            if (descriptors == null) throw new ArgumentNullException("descriptors", "descriptors cannot be null");
            #endregion

            this.descriptors = descriptors;
            RowKey = rowKey;
            ConstituentRows = new Dictionary<ITable, IConstituentRow>();
        }
        #endregion

        #region Implementation of IRowData
        /// <summary>
        /// Unique Row Key
        /// </summary>
        public object RowKey { get; private set; }

        /// <summary>
        /// Source rows which hold the actual data
        /// </summary>
        public IDictionary<ITable, IConstituentRow> ConstituentRows { get; private set; }

        /// <summary>
        /// Return the data value for a given column
        /// </summary>
        /// <param name="column">Source column to lookup</param>
        /// <returns>cell value of default for column type</returns>
        public object GetCellData(IColumn column)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation Of ICustomTypeDescriptor
        public AttributeCollection GetAttributes()
        {
            return attributeCollection;
        }

        public string GetClassName()
        {
            return null;
        }

        public string GetComponentName()
        {
            return "IRowData";
        }

        public TypeConverter GetConverter()
        {
            return null;
        }

        public EventDescriptor GetDefaultEvent()
        {
            throw new NotImplementedException();
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            throw new NotImplementedException();
        }

        public object GetEditor(Type editorBaseType)
        {
            throw new NotImplementedException();
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            throw new NotImplementedException();
        }

        public EventDescriptorCollection GetEvents()
        {
            throw new NotImplementedException();
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return descriptors;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = (s,e) => { };
        #endregion
    }
}
