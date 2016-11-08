using System;
using System.Collections.Generic;
using System.Text;

using pstsdk.definition.ndb.node;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ltp.table
{
    public interface ITable
    {
        IPropertyObject this[UInt32 row] { get; }
        IEnumerable<IPropertyObject> Rows { get; }

        UInt64 GetCellValue(UInt32 row, PropId id);
        INode Node { get; }

        IEnumerable<PropId> PropList { get; }
        PropertyType GetPropType(PropId id);

        IRowID GetRowID(UInt32 row);
        UInt32 LookupRow(IRowID id);

        IHnidStreamDevice OpenCellStream(UInt32 row, PropId id);
        byte[] ReadCell(UInt32 row, PropId id);
        int Size { get; }
    }
}
