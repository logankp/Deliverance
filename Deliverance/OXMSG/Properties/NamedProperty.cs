using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG.Properties
{
    /// <summary>
    /// [MS-OXMSG] 1.1
    /// A property that is identified by both a GUID and either a string name or a 32-bit identifier.
    /// </summary>
    class NamedProperty
    {
        internal Guid GUID { get; set; }

        internal int ID { get; set; } //if the property is a numerical named property

        internal string Name { get; set; } //if the property is a string named property

        internal PropertyEntry Entry { get; set; }
    }
}
