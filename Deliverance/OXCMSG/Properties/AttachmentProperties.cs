using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXCMSG.Properties
{
    /// <summary>
    /// 
    /// </summary>
    /// //See https://msdn.microsoft.com/en-us/library/ee179470(v=exchg.80).aspx
    class AttachmentProperties
    {
        internal const short PidTagLastModificationTime = 0x3008;
        internal const short PidTagCreationTime = 0x3007;
        internal const short PidTagDisplayName = 0x3001;
        internal const short PidTagAttachSize = 0x0E20;
        internal const short PidTagAttachNumber = 0x0E21;
        internal const short PidTagAttachDataBinary = 0x3701; //this is the one!
        internal const short PidTagAttachMethod = 0x3705;
        internal const short PidTagAttachLongFilename = 0x3707;
        internal const short PidTagAttachFilename = 0x3704; //don't use this, it's the DOS name
        internal const short PidTagAttachExtension = 0x3703;
        internal const short PidTagAttachLongPathname = 0x370D;
        internal const short PidTagAttachPathname = 0x3708; //don't use this, it's the DOS name

    }
}
