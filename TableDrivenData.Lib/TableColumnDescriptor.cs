using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Custom property descriptor for a given column
    /// </summary>
    public class TableColumnDescriptor : PropertyDescriptor
    {
        #region Instance Members
        readonly IColumn column;
        readonly IWriteService writeService;
        #endregion

        #region Constructors
        public TableColumnDescriptor(IColumn column) : base(column.Key, null)
        {
            this.column = column;
        }
        public TableColumnDescriptor(IColumn column, IWriteService writeService) : this(column)
        {
            this.writeService = writeService;
        }
        #endregion

        #region Overrides
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        public override string Description
        {
            get { return column.Description; }
        }
        public override string DisplayName
        {
            get { return column.Name; }
        }
        public override Type ComponentType
        {
            get { return typeof(IRowData); }
        }
        public override bool IsReadOnly
        {
            get { return !column.IsWritable; }
        }
        public override Type PropertyType
        {
            get { return column.Type; }
        }
        public override object GetValue(object component)
        {
            var row = component as IRowData;
            if (row != null)
                return row.GetCellData(column);

            return null;
        }
        public override void SetValue(object component, object value)
        {
            var row = component as IRowData;
            if (row != null && column.IsWritable && writeService != null)
                writeService.Write(row, column, value);
        }
        #endregion
    }
}
