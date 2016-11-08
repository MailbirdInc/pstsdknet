using System;
using System.Collections.Generic;
using System.Text;

using pstsdk.definition.ltp.propbag;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;

namespace pstsdk.mcpp.sample.storeinfo
{
    class Program
    {
        static void Main(string[] args)
        {

            IDatabaseContext db = Database.OpenDatabase(args[0]);
            
            //IPropertyBag store = new PropertyBag(db.LookupNode((UInt32)PredefinedNid.nid_message_store));

            /*List<IPropID> props = store.GetPropList();
            
            for(int i = 0; i < props.Count; ++i)
            {
                Console.WriteLine("0x" + Convert.ToString(props[i].PropID, 16));
            }*/
        }
    }
}
