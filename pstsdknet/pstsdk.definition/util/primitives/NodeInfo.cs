using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.util.primitives
{
    public struct NodeInfo
    {
        public NodeID NodeId { get; set; }
        public BlockID DataBlockId { get; set; }
        public BlockID SubBlockId { get; set; }
        public NodeID ParentNodeId { get; set; }

        public override string ToString()
        {
            return
                String.Format("NodeId = {0}, DataBlockId = {1}, SubBlockId = {2}, ParentNodeId = {3}",
                              NodeId, DataBlockId, SubBlockId, ParentNodeId);
        }
    }
}
