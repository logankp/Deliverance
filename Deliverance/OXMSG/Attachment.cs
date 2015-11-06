using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXCMSG.Properties;
using Deliverance.OXMSG.Properties;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// This class represents an email attachment
    /// </summary>
    public class Attachment : Storage
    {
        /// <summary>
        /// Returns the name of the atachment
        /// </summary>
        public string FileName
        {
            get
            {
                return GetProperty(AttachmentProperties.PidTagAttachLongFilename).ToString();
            }
        }

        /// <summary>
        /// Returns the extension of the attachment
        /// </summary>
        public string Extension
        {
            get
            {
                return GetProperty(AttachmentProperties.PidTagAttachExtension)?.ToString();
            }
        }

        /// <summary>
        /// Returns the actual attachment
        /// </summary>
        public object AttachmentData
        {
            get
            {
                return GetProperty(AttachmentProperties.PidTagAttachDataBinary);
            }
        }
    }
}
