using System.Collections.Generic;
using System.Text;

using pstsdk.definition.ndb.node;
using pstsdk.definition.util.errors;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.database
{
    /// <summary>
    /// <para>
    ///  Database external interface
    ///  </para>
    /// <para>
    /// The db_context is the iterface which all components, ndb and up,
    /// use to access the PST file. It is basically an object factory; given an
    /// address (or other relative context to help locate the physical piece of
    /// data) a db_context will produce an in memory version of that data
    /// structure, with all the Unicode vs. ANSI differences abstracted away.
    /// </para>
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        /// Open a node
        /// </summary>
        /// <param name="nid">The id of the node to lookup</param>
        /// <returns>A node instance</returns>
        INode LookupNode(NodeID nid);


        /// <summary>
        /// Lookup information about a node
        /// </summary>
        /// <param name="nid">The id of the node to lookup</param>
        /// <returns>Information about the specified node</returns>
        INodeInfo LookupNodeInfo(NodeID nid);

        /// <summary>
        /// Lookup information about a block
        /// </summary>
        /// <typeparam name="T">The id of the block to lookup</typeparam>
        /// <param name="bid"></param>
        /// <returns>Information about the specified block</returns>
        IBlockInfo LookupBlockInfo(BlockID bid);

        // Page factory functions
        
        IBBTPage ReadBBTRoot();
        INBTPage ReadNBTRoot();
        IBBTPage ReadBBTPage(IPageInfo pi);
        INBTPage ReadNBTPage(IPageInfo pi);
        INBTLeafPage ReadNBTLeafPage(IPageInfo pi);
        IBBTLeafPage ReadBBTLeafPage(IPageInfo pi);
        INBTNonLeafPage ReadNBTNonLeafPage(IPageInfo pi);
        IBBTNonLeafPage ReadBBTNonLeafPage(IPageInfo pi);

        // Block factory functions

        /// <summary>
        /// Open a block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        IBlock ReadBlock(BlockID bid);

        /// <summary>
        /// Open a data_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        IDataBlock ReadDataBlock(BlockID bid);


        /// <summary>
        /// Open a extended_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        IExtendedBlock ReadExtendedBlock(BlockID bid);

        /// <summary>
        /// Open a external_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        IExternalBlock ReadExternalBlock(BlockID bid);


        /// <summary>
        /// Open a sub_node_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeBlock ReadSubNodeBlock(BlockID bid);

        /// <summary>
        /// Open a sub_node_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeLeafBlock ReadSubNodeLeafBlock(BlockID bid);

        /// <summary>
        /// Open a sub_node_non_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeNonLeafBlock ReadSubNodeNonLeafBlock(BlockID bid);


        /// <summary>
        /// Open a block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <returns>The requested block</returns>
        IBlock ReadBlock(IDatabaseContext parent, BlockID bid);

        /// <summary>
        /// Open a data_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bid">The id of the block to open</param>
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <returns>The requested block</returns>
        IDataBlock ReadDataBlock(IDatabaseContext parent, BlockID bid);


        /// <summary>
        /// Open a extended_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        IExtendedBlock ReadExtendedBlock(IDatabaseContext parent, BlockID bid);

        /// <summary>
        /// Open a external_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        IExternalBlock ReadExternalBlock(IDatabaseContext parent, BlockID bid);


        /// <summary>
        /// Open a sub_node_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeBlock ReadSubNodeBlock(IDatabaseContext parent, BlockID bid);

        /// <summary>
        /// Open a sub_node_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeLeafBlock ReadSubNodeLeafBlock(IDatabaseContext parent, BlockID bid);

        /// <summary>
        /// Open a sub_node_non_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bid">The id of the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeNonLeafBlock ReadSubNodeNonLeafBlock(IDatabaseContext parent, BlockID bid);



        /// <summary>
        /// Open a block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        IBlock ReadBlock(IBlockInfo bi);

        /// <summary>
        /// Open a data_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        IDataBlock ReadDataBlock(IBlockInfo bi);


        /// <summary>
        /// Open a extended_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        IExtendedBlock ReadExtendedBlock(IBlockInfo bi);

        /// <summary>
        /// Open a external_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        IExternalBlock ReadExternalBlock(IBlockInfo bi);


        /// <summary>
        /// Open a sub_node_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeBlock ReadSubNodeBlock(IBlockInfo bi);

        /// <summary>
        /// Open a sub_node_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeLeafBlock ReadSubNodeLeafBlock(IBlockInfo bi);

        /// <summary>
        /// Open a sub_node_non_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeNonLeafBlock ReadSubNodeNonLeafBlock(IBlockInfo bi);


        /// <summary>
        /// Open a block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <returns>The requested block</returns>
        IBlock ReadBlock(IDatabaseContext parent, IBlockInfo bi);

        /// <summary>
        /// Open a data_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="bi">Information about the block to open</param>
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <returns>The requested block</returns>
        IDataBlock ReadDataBlock(IDatabaseContext parent, IBlockInfo bi);


        /// <summary>
        /// Open a extended_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        IExtendedBlock ReadExtendedBlock(IDatabaseContext parent, IBlockInfo bi);

        /// <summary>
        /// Open a external_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        IExternalBlock ReadExternalBlock(IDatabaseContext parent, IBlockInfo bi);


        /// <summary>
        /// Open a sub_node_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeBlock ReadSubNodeBlock(IDatabaseContext parent, IBlockInfo bi);

        /// <summary>
        /// Open a sub_node_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeLeafBlock ReadSubNodeLeafBlock(IDatabaseContext parent, IBlockInfo bi);

        /// <summary>
        /// Open a sub_node_non_leaf_block in this context
        ///  </summary>
        /// <exception cref="UnexpectedBlockException">If the parameters of the block appear incorrect</exception>
        /// <exception cref="SignatureMismatchException">If the block trailer's signature appears incorrect</exception>
        /// <exception cref="CRCFailureException">If the block's CRC doesn't match the trailer
        /// <param name="parent">The context to open this block in. It must be either this context or a child context of this context.</param>
        /// <param name="bi">Information about the block to open</param>
        /// <returns>The requested block</returns>
        ISubNodeNonLeafBlock ReadSubNodeNonLeafBlock(IDatabaseContext parent, IBlockInfo bi);



        IExternalBlock CreateExternalBlock(int size);
        IExtendedBlock CreateExtendedBlock(IExternalBlock block);
        IExtendedBlock CreateExtendedBlock(IExtendedBlock block);
        IExtendedBlock CreateExtendedBlock(int size);

        IExternalBlock CreateExternalBlock(IDatabaseContext parent, int size);
        IExtendedBlock CreateExtendedBlock(IDatabaseContext parent, IExternalBlock block);
        IExtendedBlock CreateExtendedBlock(IDatabaseContext parent, IExtendedBlock block);
        IExtendedBlock CreateExtendedBlock(IDatabaseContext parent, int size);

        BlockID AllocBid(bool isInternal);
    }
}
