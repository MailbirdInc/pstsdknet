//using System.Collections.Generic;

//using pstsdk.definition.util.primitives;

//namespace pstsdk.definition.ltp.table
//{
//    public interface ITableRow : IPropertyObject
//    {
//        IEnumerable<PropId> PropList { get; }
//        PropertyType GetPropType(PropId id);
//        IRowID RowID { get; }
//        byte GetValue1(PropId id);
//        ushort GetValue2(PropId id);
//        uint GetValue4(PropId id);
//        ulong GetValue8(PropId id);
//        byte[] GetValueVariable(PropId id);
//        IHnidStreamDevice OpenPropStream(PropId id);
//        bool PropExists(PropId prop);
//        // Size { get; }
//    }
//}