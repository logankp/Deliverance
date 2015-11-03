using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG.Headers
{
    /// <summary>
    /// The base header shared by all property streams
    /// </summary>
    internal class BaseHeader
    {
        internal const int HEADER_SIZE_BYTES = 8; //8 bytes of reserved space for the base header
        /// <summary>
        /// This field MUST be set to zero when writing a .msg file and MUST be ignored when reading a .msg file.
        /// </summary>
        internal long Reserved
        {
            get { return 0x0; }
        }

    }
}
