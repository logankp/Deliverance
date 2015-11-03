using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Deliverance.OXMSG.Properties;
using Deliverance.OXMSG.StreamReaders;
using OpenMcdf;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// This class handles getting properties from the MSG file.
    /// TODO: Still need to handle multivalue properties.
    /// </summary>
    class MsgParser
    {
        private CompoundFile _compoundFile;
        private NamedPropertyParser _namedPropertyParser;
        private PropertyStreamReader _propStreamReader;
        private RecipientReader _recipientReader;
        internal MsgParser(string filePath)
        {
            _compoundFile = new CompoundFile(filePath);
            _namedPropertyParser = new NamedPropertyParser(_compoundFile);
            _propStreamReader = new PropertyStreamReader(_compoundFile);
            _recipientReader = new RecipientReader(_compoundFile);
        }

        /// <summary>
        /// This method will create a raw MSG structure
        /// </summary>
        internal Message Parse()
        {
            Message message = new Message();
            var propertyStream = _propStreamReader.ReadPropertyStream();
            message.PropertyStream = propertyStream;
            message.NamedProperties = ParseNamedProperties(propertyStream);
            message.Recipients = new List<Recipient>();
            for (short i = 0; i < message.PropertyStream.Header.RecipientCount; i++)
            {
                var recipient = new Recipient() { PropertyStream = _recipientReader.ReadPropertyStream(i) };
                message.Recipients.Add(recipient);
            }

            return message;
        }

        /// <summary>
        /// This will get and parse named properties
        /// </summary>
        /// <param name="ps">A populated property stream</param>
        /// <returns>A list of NamedProperty objects</returns>
        private List<NamedProperty> ParseNamedProperties(PropertyStream ps)
        {
            NamedPropertyMapper mapper = new NamedPropertyMapper(_namedPropertyParser);
            List<PropertyEntry> namedPropertyEntries = GetNamedProperties(ps);
            List<NamedProperty> namedProperties = new List<NamedProperty>();
            foreach (var property in namedPropertyEntries)
            {
                namedProperties.Add(mapper.MapProperty(property));
            }
            return namedProperties;
        }

        /// <summary>
        /// This method returns the stream names of named properties
        /// </summary>
        /// <returns></returns>
        private List<PropertyEntry> GetNamedProperties(PropertyStream ps)
        {
            List<PropertyEntry> namedProperties = new List<PropertyEntry>();
            foreach (var item in ps.Data)
            {
                if (item.PropertyTag.ID >= 0x8000 && item.PropertyTag.ID <= 0x8FFF)
                {
                    namedProperties.Add(item);
                }
            }
            return namedProperties;
        }
    }
}
