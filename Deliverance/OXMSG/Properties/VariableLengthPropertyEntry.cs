using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG.Properties
{
    /// <summary>
    /// 2.4.2.2 https://msdn.microsoft.com/en-us/library/ee236936(v=exchg.80).aspx
    /// </summary>
    class VariableLengthPropertyEntry : PropertyEntry
    {
        private int _size;
        /// <summary>
        /// This value is interpreted based on the property type, which is specified in the Property Tag field.
        /// If the message contains an embedded message attachment or a storage attachment, this field MUST be set to 0xFFFFFFFF.
        /// Otherwise, the following table shows how this field is interpreted for each property type.
        /// The property types are specified in [MS-OXCDATA] section 2.11.1.
        /// </summary>
        internal int Size
        {
            get { return BitConverter.ToInt32(Value, 0); }
            set { _size = value; }
        }

        /// <summary>
        /// This field MUST be ignored when reading a .msg file.
        /// When writing a .msg file, this field MUST be set to 0 if the message does not contain an attachment.
        /// This field MUST be set to 0x01 if the message contains an embedded message attachment and to 0x04 if the message contains a storage attachment.
        /// The following table shows the required value for this field based on the value of the PidTagAttachMethod property ([MS-OXCMSG] section 2.2.2.9).
        /// </summary>
        internal int Reserved { get; set; }

        internal object VariableLengthData { get; set; }

        /// <summary>
        /// This will return the name of the stream that contains this property
        /// </summary>
        internal string StreamName { get; set; }

        // PidTagAttachMethod property value    Required Reserved field value
        // ATTACH_EMBEDDED_MSG (0x00000005)     0x01
        // ATTACH_OLE (0x00000006)              0x04
    }
}
