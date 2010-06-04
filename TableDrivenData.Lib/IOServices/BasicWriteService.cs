using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel.Composition;

namespace NickField.TableDrivenData.Lib.IOServices
{
    [Export(typeof(IWriteService))]
    public class BasicWriteService : IWriteService
    {
        public void Write(IRowData row, IColumn column, object value)
        {
            throw new NotImplementedException();
        }
    }
}
