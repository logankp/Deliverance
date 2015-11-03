using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG.Headers
{
    /// <summary>
    /// 2.4.1.1
    /// The header for the property stream contained inside the top level of the .msg file,
    /// which represents the Message object itself, has the following structure.
    /// </summary>
    class TopLevelHeader : BaseHeader
    {
        internal new const int HEADER_SIZE_BYTES = 32;
        /// <summary>
        /// The ID to use for naming the next Recipient object storage if one is created inside the .msg file.
        /// The naming convention to be used is specified in section 2.2.1.
        /// If no Recipient object storages are contained in the .msg file, this field MUST be set to 0.
        /// </summary>
        internal int NextRecipientId { get; set; }

        /// <summary>
        /// The ID to use for naming the next Attachment object storage if one is created inside the .msg file.
        /// The naming convention to be used is specified in section 2.2.2.
        /// If no Attachment object storages are contained in the .msg file, this field MUST be set to 0.
        /// </summary>
        internal int NextAttachmentId { get; set; }

        /// <summary>
        /// The number of Recipient objects.
        /// </summary>
        internal int RecipientCount { get; set; }

        /// <summary>
        /// The number of Attachment objects.
        /// </summary>
        internal int AttachmentCount { get; set; }
    }
}
