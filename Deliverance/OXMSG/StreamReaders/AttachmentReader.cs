using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG.Properties;
using OpenMcdf;

namespace Deliverance.OXMSG.StreamReaders
{
    /// <summary>
    /// This class reads from the attachment storages
    /// This and the recipient reader can probably be sub-classes at some point
    /// </summary>
    class AttachmentReader
    {
        private PropertyStreamReader _propStreamReader;

        internal AttachmentReader(CompoundFile cf)
        {
            _propStreamReader = new PropertyStreamReader(cf);
        }

        internal PropertyStream ReadPropertyStream(short attachNumber) //there can be up to 2048 attachments
        {
            var propertyStream = _propStreamReader.ReadPropertyStream(string.Format("__attach_version1.0_#{0:X8}", attachNumber));
            return propertyStream;
        }
    }
}
