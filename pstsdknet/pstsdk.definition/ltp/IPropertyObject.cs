using System;
using System.Collections.Generic;
using System.IO;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ltp
{
    public interface IPropertyObject : IDisposable
    {
        ///<summary>
        ///   The NodeID of this search folder
        ///</summary>
        NodeID Node { get; } 
        /// <summary>
        ///     An enumeration of all valid PropertyIds for this object
        /// </summary>
        IEnumerable<PropId> Properties { get; }
        /// <summary>
        ///     Determines the property type of a specific PropertyId
        /// </summary>
        /// <param name="id"><see cref="PropId"/> to check type</param>
        /// <returns>A <see cref="PropertyType"/> indicating the type</returns>
        PropertyType GetPropertyType(PropId id);
        /// <summary>
        ///     Checks if a property exists in a PropertyObject
        /// </summary>
        /// <param name="id"><see cref="PropId"/> to verify</param>
        /// <returns>true if the property exists; otherwise, false</returns>
        bool PropertyExists(PropId id);
        /// <summary>
        ///     Gets the size of a given property
        /// </summary>
        /// <param name="id"><see cref="PropId"/> to lookup</param>
        /// <returns>An unsigned int representing the size of the property</returns>
        uint PropertySize(PropId id);

        /// <summary>
        ///     A byte array of the property data
        /// </summary>
        /// <param name="id"><see cref="PropId"/> to read</param>
        /// <returns>The property data as an array of bytes</returns>
        byte[] ReadProperty(PropId id);
        /// <summary>
        ///     Gets/Opens a stream to the property data
        /// </summary>
        /// <param name="id"><see cref="PropId"/> to read</param>
        /// <returns>A stream to the property data</returns>
        Stream OpenPropertyStream(PropId id);
    }
}