using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG.Properties
{
    /// <summary>
    /// A 32-bit value that contains a property type and a property ID.
    /// The low-order 16 bits represent the property type. The high-order 16 bits represent the property ID.
    /// https://msdn.microsoft.com/en-us/library/ee200563.aspx#gt_550ffe03-4145-49d1-8370-a9906b00452c
    /// </summary>
    class PropertyTag
    {
        /// <summary>
        /// The high-order 16 bits represent the property ID.
        /// </summary>
        internal ushort ID { get; set; }

        /// <summary>
        /// The low-order 16 bits represent the property type.
        /// </summary>
        internal PropertyType Type { get; set; }

        //Type|ID
    }
}
