using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.util.primitives
{
    public struct BlockInfo
    {
        public BlockID BlockId { get; set; }
        public Int64 Address { get; set; }
        public ushort Size { get; set; }
        public ushort RefCount { get; set; }

        public override string ToString()
        {
            return
                String.Format("BlockId = {0}, Address = {1}, Size = {2}, RefCount = {3}",
                              BlockId, Address, Size, RefCount);
        }
    }
}