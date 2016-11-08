using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.util.primitives
{
    public struct NameId
    {
        public static int NameIdSize = 8;

        public uint Id;
        public uint GuidIndex;
        public uint PropertyIndex;

        private bool _isString;

        public NameId(Byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                Id = 0;
                GuidIndex = 0;
                PropertyIndex = 0;
                _isString = false;
            }
            else
            {
                Id = BitConverter.ToUInt32(bytes, 0);
                GuidIndex = BitConverter.ToUInt16(bytes, 4);

                _isString = (GuidIndex & 1) == 1;
                GuidIndex >>= 1;

                PropertyIndex = BitConverter.ToUInt16(bytes, 6);
            }
        }

        public static implicit operator NameId(byte[] b)
        {
            return new NameId(b);
        }

        public override string ToString()
        {
            return string.Format("Id/String Offset: {0}" + Environment.NewLine +
                          "Guid Index: {1}" + Environment.NewLine +
                          "Property Index: {2}" + Environment.NewLine +
                          "Is String: {3}", Id, GuidIndex, PropertyIndex, IsString);
        }

        public bool IsString
        {
            get { return _isString; }
            set { _isString = value; }
        }
    }
}
