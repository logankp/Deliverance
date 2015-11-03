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
    /// This class will read from the property stream and populate the data.
    /// It handles both fixed-length and variable-length properties.
    /// </summary>
    class PropertyStreamReader
    {
        private CompoundFile _compoundFile;

        internal PropertyStreamReader(CompoundFile cf)
        {
            _compoundFile = cf;
        }

        /// <summary>
        /// The class will read and parse a property stream.
        /// See https://msdn.microsoft.com/en-us/library/ee203894(v=exchg.80).aspx for the structure.
        /// </summary>
        /// <param name="storage">Which storage to read from. If null, read from the top-level storage</param>
        /// <returns>A populated Property Stream</returns>
        internal PropertyStream ReadPropertyStream(string storage = null)
        {
            PropertyStream ps = new PropertyStream();
            ps.Header = new Headers.TopLevelHeader();
            CFStream propStream;
            byte[] data;
            if (storage == null) // we want the top-level property stream
            {
                propStream = _compoundFile.RootStorage.GetStream(PropertyStream.STREAM_NAME);
                data = propStream.GetData();
                ps.Header.NextRecipientId = BitConverter.ToInt32(data, 8);
                ps.Header.NextAttachmentId = BitConverter.ToInt32(data, 12);
                ps.Header.RecipientCount = BitConverter.ToInt32(data, 16);
                ps.Header.AttachmentCount = BitConverter.ToInt32(data, 20);
                ps.NumberOfProperties = (data.Length - Headers.TopLevelHeader.HEADER_SIZE_BYTES) / PropertyEntry.SIZE_BYTES;
                ps.Data = new List<PropertyEntry>();
                for (int i = 0; i < ps.NumberOfProperties; i++)
                {
                    //start reading at 32
                    ps.Data.Add(ReadPropertyEntry(data.Skip(Headers.TopLevelHeader.HEADER_SIZE_BYTES).Skip(i * 16).Take(16).ToArray()));
                }
            }
            else //we want the attachment/recipient property stream
            {
                propStream = _compoundFile.RootStorage.GetStorage(storage).GetStream(PropertyStream.STREAM_NAME);
                data = propStream.GetData();
                ps.NumberOfProperties = (data.Length - Headers.BaseHeader.HEADER_SIZE_BYTES) / PropertyEntry.SIZE_BYTES;
                ps.Data = new List<PropertyEntry>();
                for (int i = 0; i < ps.NumberOfProperties; i++)
                {
                    //start reading at 8
                    ps.Data.Add(ReadPropertyEntry(data.Skip(Headers.BaseHeader.HEADER_SIZE_BYTES).Skip(i * 16).Take(16).ToArray()));
                }
            }
            PopulateVariableLengthProperties(ps, storage);
            return ps;
        }

        /// <summary>
        /// This will read an entry from the property stream
        /// </summary>
        /// <param name="entry">An array of bytes representing an entry</param>
        /// <returns>A parsed PropertyEntry structure</returns>
        private PropertyEntry ReadPropertyEntry(byte[] entry)
        {
            PropertyEntry propEntry;
            PropertyTag tag = new PropertyTag();
            tag.Type = (PropertyType)BitConverter.ToInt16(entry, 0);
            tag.ID = BitConverter.ToUInt16(entry, 2);
            if (TypeMapper.IsFixedLength(tag.Type))
            {
                propEntry = new PropertyEntry();
            }
            else
            {
                propEntry = new VariableLengthPropertyEntry();
            }

            propEntry.PropertyTag = tag;
            propEntry.Flags = BitConverter.ToInt32(entry, 4);
            propEntry.Value = entry.Skip(8).ToArray();

            return propEntry;
        }

        /// <summary>
        /// Populates the value of variable length properties
        /// </summary>
        private void PopulateVariableLengthProperties(PropertyStream ps, string storage)
        {
            var variableLengthReader = new VariableLengthStreamReader(_compoundFile);
            foreach (var item in ps.Data)
            {
                if (!TypeMapper.IsFixedLength(item.PropertyTag.Type))
                {
                    object obj = variableLengthReader.GetVariableLengthProperty(item, storage);
                    (item as VariableLengthPropertyEntry).VariableLengthData = obj;
                }
            }
        }
    }
}
