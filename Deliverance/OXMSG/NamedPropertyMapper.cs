using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG.Properties;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// This class will set-up the name-id mapping of named properties
    /// [MS-OXMSG] 2.2.3
    /// [MS-OXMSG] 3.2 - example
    /// </summary>
    class NamedPropertyMapper
    {
        NamedPropertyParser _propParser;

        internal NamedPropertyMapper(NamedPropertyParser parser)
        {
            _propParser = parser;
        }

        internal NamedProperty MapProperty(PropertyEntry entry)
        {
            int entryStreamIndex = GetEntryStreamIndex(entry.PropertyTag.ID); //find the index into the entry stream
            var propEntry = _propParser.Entries[entryStreamIndex]; //grab the relevent entry
            int guidIndex = GetGuidStreamIndex(propEntry.GUIDIndex); //find the index into the guid stream
            Guid guid = _propParser.Guids[guidIndex];
            NamedProperty namedProperty = new NamedProperty() { GUID = guid, Entry = entry, ID = propEntry.NameIdentifier };
            if (propEntry.IsString)
            {
                string name = _propParser.ReadStringStream(propEntry.NameIdentifier);
                namedProperty.Name = name;
            }
            return namedProperty;
        }
        /// <summary>
        /// Determines the offset into the entry list for this property
        /// [MS-OXMSG] 3.2.1.1
        /// NOTE: Since these are loaded into a list, I don't need to calculate the stream offset
        /// </summary>
        /// <param name="propId">The property id between 0x8000 and 0x8FFF</param>
        /// <returns>The offset into the entry stream</returns>
        private int GetEntryStreamIndex(int propId)
        {
            return (propId - 0x8000); //* 0x08;
        }

        /// <summary>
        /// Determines the offset into the Guid stream for this property
        /// [MS-OXMSG] 3.2.1.2
        /// NOTE: Since these are loaded into a list, I don't need to calculate the stream offset
        /// </summary>
        /// <param name="guidIndex">The GUID index</param>
        /// <returns>The offset into the GUID stream</returns>
        private int GetGuidStreamIndex(short guidIndex)
        {
            return (guidIndex - 0x03); //* 0x10;
        }


    }
}
