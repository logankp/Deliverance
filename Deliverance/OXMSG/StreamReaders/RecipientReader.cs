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
    /// This class will read from the recipient storage and populate the relevant items
    /// </summary>
    class RecipientReader
    {
        private PropertyStreamReader _propStreamReader;

        internal RecipientReader(CompoundFile cf)
        {
            _propStreamReader = new PropertyStreamReader(cf);
        }

        internal PropertyStream ReadPropertyStream(short recipientNumber) //there can be up to 2048 recipients
        {
            var propertyStream = _propStreamReader.ReadPropertyStream(string.Format("__recip_version1.0_#{0:X8}", recipientNumber));
            return propertyStream;
        }
    }
}
