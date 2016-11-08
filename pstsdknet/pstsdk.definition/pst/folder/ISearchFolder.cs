using System.Collections.Generic;
using pstsdk.definition.ltp;
using pstsdk.definition.ltp.propbag;
using pstsdk.definition.ltp.table;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.pst.folder
{
    /// <summary>
    ///     Search Folder object
    /// <para>
    ///     Search folders are different from regular folders mainly in that they
    ///     do not have a hierarchy table (and thus no subfolders). The messages
    ///     they "contain" are actually in other folders.
    /// </para>
    /// <para>
    ///     This object exists to reflect that limited interface. Eventually this
    ///     object may support querying the criteria used to create the search folder.
    /// </para>
    /// </summary>
    public interface ISearchFolder : IPropertyObject
    {
        /// <summary>
        ///     The display name of this folder
        /// </summary>
        /// <returns>
        ///     The Name of this folder
        /// </returns>
        string Name { get; }
        /// <summary>
        ///     Returns the underlying DatabaseContext object
        /// </summary>
        /// <seealso cref="IDBAccessor"/>
        IDBAccessor DatabaseContext { get; }
        /// <summary>
        ///     The number of messages in this folder
        /// </summary>
        int MessageCount { get; }

        /// <summary>
        ///     An enumeration of all of the <see cref="IMessage"/>
        /// </summary>
        /// <returns>
        ///     An IEnumerable of IMessage.
        /// </returns>
        IEnumerable<IMessage> Messages { get; }
    }
}