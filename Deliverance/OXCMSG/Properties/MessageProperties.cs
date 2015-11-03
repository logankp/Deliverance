using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG.Properties;

namespace Deliverance.OXCMSG.Properties
{

    class MessageProperties
    {
        /// The following properties exist on all Message objects. These properties are read-only for the client.
        /// [MS-OXCMSG] 2.2.1.1
        internal const short PidTagAccess = 0x0FF4;
        internal const short PidTagAccessLevel = 0x0FF7;
        internal const short PidTagChangeKey = 0x65E2;
        internal const short PidTagCreationTime = 0x3007;
        internal const short PidTagLastModificationTime = 0x3008;
        internal const short PidTagLastModifierName = 0x3FFA;
        //PidTagObjectType not supported
        //PidTagRecordKey not supported
        internal const short PidTagSearchKey = 0x300B;

        //body properties
        internal const short PidTagBody = 0x1000;
        internal const short PidTagBodyHtml = 0x1013;

        //other
        internal const short PidTagSubject = 0x0037;
        internal const short PidTagOriginalSenderEmailAddress = 0x0067;
        internal const short PidTagSenderEmailAddress = 0x0C1F;
        internal const short PidTagOriginalSenderName = 0x005A;
        internal const short PidTagSenderName = 0x0C1A;
        internal const short PidTagSenderSmtpAddress = 0x5D01;
        internal const short PidTagDisplayBcc = 0x0E02;
        internal const short PidTagDisplayCc = 0x0E03;
        internal const short PidTagDisplayTo = 0x0E04;
        internal const short PidTagEmailAddress = 0x3003;
    }
}
