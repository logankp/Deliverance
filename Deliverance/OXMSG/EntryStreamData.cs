using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// 2.2.3.1.2 Entry Stream
    /// The entry stream (1) MUST be named "__substg1.0_00030102" and consist of 8-byte entries, one for each named property being stored.
    /// https://msdn.microsoft.com/en-us/library/ee159689.aspx
    /// </summary>
    class EntryStreamData
    {
        internal const string STREAM_NAME = "__substg1.0_00030102";

        /// <summary>
        /// The properties are assigned unique numeric IDs (distinct from any property ID assignment) starting from a base of 0x8000.
        /// </summary>
        internal int ID { get; set; }

        /// <summary>
        /// Name Identifier/String Offset (4 bytes):
        /// If this property is a numerical named property, this value is the LID part of the PropertyName structure. 
        /// If this property is a string named property,
        /// this value is the offset in bytes into the strings stream (1) where the value of the Name field of the PropertyName structure is located.
        /// </summary>
        internal int NameIdentifier { get; set; }

        /// <summary>
        /// Property Index (2 bytes): Sequentially increasing, zero-based index. This MUST be 0 for the first named property, 1 for the second, and so on.
        /// https://msdn.microsoft.com/en-us/library/ff367982.aspx
        /// </summary>
        internal short PropertyIndex { get; set; }

        /// <summary>
        /// Index into the GUID stream.
        /// https://msdn.microsoft.com/en-us/library/ff367982.aspx
        /// </summary>
        internal short GUIDIndex { get; set; }

        // GUID Index Meaning
        // Value    GUID to use
        //  1       Always use the PS_MAPI property set, as specified in [MS-OXPROPS] section 1.3.2. No GUID is stored in the GUID stream (1).
        //  2       Always use the PS_PUBLIC_STRINGS property set, as specified in [MS-OXPROPS] section 1.3.2. No GUID is stored in the GUID stream (1).
        // >= 3     Use Value minus 3 as the index of the GUID into the GUID stream (1). For example, if the GUID index is 5, the third GUID (5 minus 3, resulting in a zero-based index of 2) is used as the GUID for the name property being derived.

        /// <summary>
        /// Property Kind (1 bit): Bit indicating the type of the property; zero (0) if numerical named property and 1 if string named property.
        /// https://msdn.microsoft.com/en-us/library/ff367982.aspx
        /// </summary>
        internal bool IsString { get; set; }
    }
}
