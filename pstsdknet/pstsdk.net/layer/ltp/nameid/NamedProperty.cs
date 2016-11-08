using System;
using pstsdk.definition.ltp.nameid;

namespace pstsdk.layer.ltp.nameid
{
    public class NamedProperty : INamedProperty
    {
        public NamedProperty(Guid guid, uint id)
        {
            Guid = guid;
            ID = id;
            IsString = false;
        }

        public NamedProperty(Guid guid, string name)
        {
            Guid = guid;
            Name = name;
            IsString = true;
        }

        public Guid Guid { get; private set; }
        public bool IsString { get; private set; }
        public uint ID { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            if(IsString)
                return string.Format("Guid: {0}" + Environment.NewLine +
                                 "Name: \"{1}\" " + Environment.NewLine +
                                 "IsString: {2}", Guid, Name, IsString);

            return string.Format("Guid: {0}" + Environment.NewLine +
                                 "ID: {1} " + Environment.NewLine +
                                 "IsString: {2}", Guid, ID, IsString);
        }
    }
}
