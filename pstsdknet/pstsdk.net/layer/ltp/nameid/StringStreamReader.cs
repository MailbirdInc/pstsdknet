using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace pstsdk.layer.ltp.nameid
{
    public class StringStreamReader : IDisposable
    {
        private Stream _stringStream;

        public StringStreamReader(Stream stringStream)
        {
            _stringStream = stringStream;
        }

        public string ReadString(uint stringOffset)
        {
            var buffer = new byte[4];
            
            //Seek to string offset
            _stringStream.Seek((int)stringOffset, SeekOrigin.Begin);

            //Read String size
            _stringStream.Read(buffer, 0, 4);
            var size = BitConverter.ToUInt32(buffer, 0);

            //Read string into memory
            buffer = new byte[size];
            _stringStream.Read(buffer, 0, (int)size);

            //named properties are always unicode
            return Encoding.Unicode.GetString(buffer);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_stringStream != null)
                _stringStream.Dispose();
        }

        #endregion
    }
}
