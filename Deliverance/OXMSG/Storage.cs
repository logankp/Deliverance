using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG.Properties;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// This class represents a storage.
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// 2.4
        /// Exacly one property stream, and it MUST contain entries for all properties of the message object
        /// </summary>
        internal PropertyStream PropertyStream { get; set; }

        protected internal object GetProperty(short propertyId)
        {
            var data = PropertyStream.Data.FirstOrDefault(x => x.PropertyTag.ID == propertyId);
            if (data != null)
            {
                if (TypeMapper.IsFixedLength(data.PropertyTag.Type))
                {
                    return TypeMapper.ParseEntry(data);
                }
                else
                {
                    return (data as VariableLengthPropertyEntry).VariableLengthData;
                }
            }
            else { return null; }
        }

        internal void SetProperty(PropertyTag tag, object data)
        {
            PropertyEntry entry;
            if (TypeMapper.IsFixedLength(tag.Type))
            {
                entry = new PropertyEntry();
                entry.PropertyTag = tag;
                entry.Value = TypeMapper.ObjectToByteArray(data);
            }
            else
            {
                entry = new VariableLengthPropertyEntry();
                entry.PropertyTag = tag;
                (entry as VariableLengthPropertyEntry).VariableLengthData = data;
                if (tag.Type == PropertyType.PtypString)
                {
                    (entry as VariableLengthPropertyEntry).Size = data.ToString().Length + 2;
                }
                else if (tag.Type == PropertyType.PtypString8)
                {
                    (entry as VariableLengthPropertyEntry).Size = data.ToString().Length + 1;
                }
                else
                {
                    (entry as VariableLengthPropertyEntry).Size = 0; //placeholder for now
                }
            }
        }
    }
}
