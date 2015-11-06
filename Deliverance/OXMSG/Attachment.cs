using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string FileName { get; set; }

        /// <summary>
        /// Returns the extension of the attachment
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Returns the actual attachment
        /// </summary>
        public object AttachmentData { get; set; }
    }
}
