using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using pstsdk.definition.exception;

namespace pstsdk.layer.ltp.nameid
{
    public class GuidStreamReader : IDisposable
    {
        private Stream _guidStream;

        public static readonly Guid MapiGuid = new Guid("00020328-0000-0000-C000-000000000046");
        public static readonly Guid PublicStringsGuid = new Guid("00020329-0000-0000-C000-000000000046");

        public GuidStreamReader(Stream guidStream)
        {
            _guidStream = guidStream;
        }

        /// <summary>
        /// Reads the nth guid from the guid stream
        /// </summary>
        /// <param name="guidIndex">Index of the guid to read</param>
        /// <returns>The guid read from the Guid stream</returns>
        public Guid ReadGuid(int guidIndex)
        {
            if (guidIndex == 0)
                return Guid.Empty;
            if (guidIndex == 1)
                return MapiGuid;
            if (guidIndex == 2)
                return PublicStringsGuid;

            var guidBytes = new byte[16];

            _guidStream.Seek((guidIndex - 3) * 16, SeekOrigin.Begin);
            _guidStream.Read(guidBytes, 0, 16);

            return new Guid(guidBytes);
        }

        /// <summary>
        /// Finds the index of the given guid in the guid stream
        /// </summary>
        /// <param name="guid">Guid to locate in the stream</param>
        /// <returns>a valid guid index (see [MS-PST] 2.4.7.1)</returns>
        /// <exception cref="PstSdkException">Thrown if the Guid could not be found</exception>
        public ushort GetGuidIndex(Guid guid)
        {
            if (guid == Guid.Empty)
                return 0;
            if (guid == MapiGuid)
                return 1;
            if (guid == PublicStringsGuid)
                return 2;

            var currentGuid = new byte[16];
            ushort num = 0;

            while(_guidStream.Read(currentGuid, 0, 16) != 0)
            {
                if (new Guid(currentGuid) == guid)
                    return (ushort)(num + 3);
                num++;
            }

            throw new PstSdkException("Could not locate Guid!");
        }

        #region IDisposable Members

        public void Dispose()
        {
            _guidStream.Dispose();
        }

        #endregion
    }
}
