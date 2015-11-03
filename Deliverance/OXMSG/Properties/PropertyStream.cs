using System.Collections.Generic;
using Deliverance.OXMSG.Headers;

namespace Deliverance.OXMSG.Properties
{
    /// <summary>
    /// "__properties_version1.0"
    /// The property stream MUST have the name "__properties_version1.0" and MUST consist of a header followed by an array of 16-byte entries.
    /// With the exception of Named Property Mapping storage, which is specified in section 2.2.3, every storage type specified by the .msg File Format MUST have a property stream in it.
    /// Every property of an object MUST have an entry in the property stream for that object.
    /// Fixed length properties also have their values stored as a part of the entry, whereas the values of variable length properties and multiple-valued properties are stored in separate streams.
    /// https://msdn.microsoft.com/en-us/library/ee178759(v=exchg.80).aspx
    /// </summary>
    class PropertyStream
    {
        internal const string STREAM_NAME = "__properties_version1.0";

        /// <summary>
        /// 2.4.1
        /// The header of the property stream differs depending on which storage this property stream belongs to.
        /// 
        /// </summary>
        internal TopLevelHeader Header { get; set; }

        /// <summary>
        /// The entries inside the property stream MUST be an array of 16-byte entries.
        /// The number of properties, each represented by one entry, can be determined by first measuring the size of the property stream,
        /// then subtracting the size of the header from it, and then dividing the result by the size of one entry.
        /// The structure of each entry, representing one property, depends on whether the property is a fixed length property or not.
        /// </summary>
        internal List<PropertyEntry> Data { get; set; }

        /// <summary>
        /// The number of properties can be determined by first measuring the size of the property stream,
        /// then subtracting the size of the header from it, then dividing the result by the size of one entry (16 bytes).
        /// </summary>
        internal int NumberOfProperties { get; set; }
    }
}