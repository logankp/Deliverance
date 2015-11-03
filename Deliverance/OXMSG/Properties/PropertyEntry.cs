using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG.Properties
{
    /// <summary>
    /// The data inside the property stream MUST be an array of 16-byte entries.
    /// The number of properties, each represented by one entry, can be determined by first measuring the size of the property stream, then subtracting the size of the header from it, and then dividing the result by the size of one entry.
    /// The structure of each entry, representing one property, depends on whether the property is a fixed length property or not.
    /// </summary>
    class PropertyEntry
    {
        internal const int SIZE_BYTES = 16;
        internal PropertyTag PropertyTag { get; set; }

        /// <summary>
        /// Flags giving context to the property.
        /// Possible values for this field are given in the following table (2.4.2.1). Any bitwise combination of the flags is valid.
        /// </summary>
        internal int Flags { get; set; }

        /// <summary>
        /// See 2.4.2.1.1
        /// </summary>
        internal byte[] Value { get; set; }

        internal PropertyEntry()
        {
            Value = new byte[8];
        }
    }

    /// <summary>
    /// 2.4.2.1
    /// </summary>
    internal class PropertyFlags
    {
        const int PROPATTR_MANDATORY = 0x00000001;
        const int PROPATTR_READABLE = 0x00000002;
        const int PROPATTR_WRITABLE = 0x00000004;
    }
}
