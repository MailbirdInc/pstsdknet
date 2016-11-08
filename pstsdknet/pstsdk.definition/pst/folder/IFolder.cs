using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.ltp;
using pstsdk.definition.ltp.propbag;
using pstsdk.definition.ltp.table;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.pst.folder
{
    ///<summary>
    ///   <para>
    ///      A folder in a PST file
    ///   </para>
    ///
    ///   <para>
    ///      The folder object allows access to subfolders, messages, and associated 
    ///      messagse which are contained in the folder. Similar to the <see cref="IPst"/> object,
    ///      the folder also offers a way to lookup subfolders by name.
    ///   </para>
    ///   <para>
    ///      A folder currently doesn't have a concept of sorting. This was deemed
    ///      unnecessary because of the iterator based approach used for exposing
    ///      sub messages and folders - one can use these iterators to build up a 
    ///      container of messages or folders to be sorted, and calling std::sort
    ///      directly with an arbitrary sorting functor.
    ///   </para>
    ///</summary>
    public interface IFolder : IPropertyObject
    {
        ///<summary>
        ///   The number of associated <see cref="IMessage"/> in this folder
        ///</summary>
        int AssociatedMessageCount { get; }

        ///<summary>
        ///   An enumeration of all of the associated <see cref="IMessage"/> 
        ///</summary>
        IEnumerable<IMessage> AssociatedMessages { get; }

        ///<summary>
        ///   The number of messages in this folder
        ///</summary>
        int MessageCount { get; }

        ///<summary>
        ///   An enumeration of all of the <see cref="IMessage"/> in 
        ///   this folder
        ///</summary>
        IEnumerable<IMessage> Messages { get; }

        /// <summary>
        /// Returns the underlying DatabaseContext object
        /// </summary>
        /// <seealso cref="IDBAccessor"/>
        IDBAccessor DatabaseContext { get; }

        /// <summary>
        /// Calculates and returns a EntryID for the current object
        /// </summary>
        EntryID EntryID { get; }

        ///<summary>
        ///   The display name of this folder
        ///</summary>
        ///<returns>
        ///   The Name of this folder
        ///</returns>
        string Name { get; }

        ///<summary>
        ///   The Container Class of this folder
        ///</summary>
        ///<returns>
        ///   The Container Class of this folder
        ///</returns>
        string ContainerClass { get; } 

        ///<summary>
        ///   Get the number of sub folders in this folder
        ///</summary>
        ///<returns>
        ///   The number of subfolders
        ///</returns>
        int SubFolderCount { get; }

        ///<summary>
        ///   Open a specific subfolder in this folder, not recursive
        ///</summary>
        ///<param name="name">
        ///   The name of the folder to open
        ///</param>
        ///<returns>
        ///   The first folder by that name found in this folder
        ///</returns>
        IFolder OpenSubFolder(string name);

        ///<summary>
        ///   An enumeration of all of the <see cref="IFolder"/> in 
        ///   the folder
        ///</summary>
        ///<returns>
        ///   <param>
        ///      An IEnumerable of IFolder.
        ///   </param>
        ///</returns>
        IEnumerable<IFolder> SubFolders { get; }

        /// <summary>
        /// Returns the Entry Id of the draft folder, this thould be only have value in the root folder
        /// </summary>
        EntryID GetDraftsFolderEntryId();

        /// <summary>
        /// Returns an array with the information of additioanl folders based on Index:
        /// 0: Conflicts folder
        /// 1: Sync Issues folder
        /// 2: Local Failures folder
        /// 3: Server Failures folder
        /// 4: Junk E-mail Folder 
        /// </summary>
        /// <returns></returns>
        EntryID[] GetAdditionalEntryIds();
    }
}
