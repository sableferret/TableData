using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;

namespace NickField.TableDrivenData.Lib
{
    class LockedCollection<T> : BlockingCollection<T>
    {
    }
}
