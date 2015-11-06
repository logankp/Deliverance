using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG.Properties;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// The MS-OXMSG file structure
    /// https://msdn.microsoft.com/en-us/library/cc463912.aspx
    /// </summary>
    class Message : Storage
    {
        //Property data types
        //[MS-OXCDATA] 2.11.1 https://msdn.microsoft.com/en-us/library/ee157583.aspx

        /// <summary>
        /// Indicates whether string properties within the .msg file are Unicode-encoded or not.
        /// This property defines multiple flags, but only the STORE_UNICODE_OK flag is valid. All other bits MUST be ignored. 
        /// https://msdn.microsoft.com/en-us/library/ff849785(v=exchg.80).aspx
        /// </summary>       
        const int STORE_UNICODE_OK = 0x00040000;
        private int PidTagStoreSupportMask = 0x340D;

        /// <summary>
        /// This property returns true if the PidTagStoreSupportMask property contains STORE_UNICODE_OK
        /// In other words, is this file Unicode encoded?
        /// </summary>
        internal bool IsUnicode
        {
            get
            {
                if (PropertyStream.Data.Any(x => x.PropertyTag.ID == PidTagStoreSupportMask))
                    return (BitConverter.ToInt32(PropertyStream.Data.FirstOrDefault(x => x.PropertyTag.ID == PidTagStoreSupportMask).Value, 0)
                           & STORE_UNICODE_OK) == STORE_UNICODE_OK;
                return false;
            }
        }

        //Storages
        //[MS-OXMSG] 2.2

        /// <summary>
        /// 2.2.1
        /// The Recipient object storage contains streams and substorages that store properties pertaining to one Recipient object.
        /// The Recipient object storage representing the first Recipient object is named "__recip_version1.0_#00000000". The storage representing the second is named "__recip_version1.0_#00000001" and so on. The digit suffix is in hexadecimal. For example, the storage name for the eleventh Recipient object is "__recip_version1.0_#0000000A".
        /// A .msg file can have a maximum of 2048 Recipient object storages.
        /// There is exactly one property stream, and it contains entries for all properties of the Recipient object.
        /// There is exactly one stream for each variable length property of the Recipient object, as specified in section 2.1.3.
        /// </summary>
        internal List<Recipient> Recipients { get; set; }

        /// <summary>
        /// 2.2.2
        /// The Attachment object storage contains streams and substorages that store properties pertaining to one Attachment object.
        /// </summary>
        internal List<Attachment> Attachments { get; set; }

        /// <summary>
        /// 2.3
        /// Exactly one named property mapping storage
        /// </summary>
        internal List<NamedProperty> NamedProperties { get; set; }
    }
}
