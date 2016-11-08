using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using pstsdk.definition.util.primitives;

namespace pstsdk.layer.ltp.nameid
{
    public class EntryStreamReader : IDisposable
    {
        private Stream _entryStream;

        public EntryStreamReader(Stream entryStream)
        {
            _entryStream = entryStream;
        }

        public int PropertyCount
        {
            get { return (int)_entryStream.Length / NameId.NameIdSize; }
        }

        public IEnumerable<PropId> PropertyIds
        {
            get
            {
                var propList = new List<PropId>();
                var buffer = new Byte[NameId.NameIdSize];

                while (_entryStream.Read(buffer, 0, NameId.NameIdSize) != 0)
                {
                   propList.Add((PropId)(((NameId)buffer).PropertyIndex + 0x8000));
                }

                return propList;
            }
        }

        public NameId ReadEntry(int entryIndex)
        {
            var bytes = new byte[NameId.NameIdSize];

            _entryStream.Seek(entryIndex * NameId.NameIdSize, SeekOrigin.Begin);
            _entryStream.Read(bytes, 0, NameId.NameIdSize);
            return bytes;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_entryStream != null)
                _entryStream.Dispose();
        }

        #endregion
    }
}
