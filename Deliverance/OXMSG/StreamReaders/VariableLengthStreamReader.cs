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
    /// This class reads and parses variable length properties.
    /// </summary>
    class VariableLengthStreamReader
    {
        private CompoundFile _compoundFile;
        public VariableLengthStreamReader(CompoundFile cf)
        {
            _compoundFile = cf;
        }

        /// <summary>
        /// Gets an entry from the stream represented by the PropertyEntry
        /// </summary>
        /// <param name="entry">A property entry</param>
        /// <param name="storage">The storage to read from</param>
        /// <returns>An object representing the variable-length property</returns>
        internal object GetVariableLengthProperty(PropertyEntry entry, string storage = null)
        {
            object obj;
            CFStream stream;
            //Get the value of the property.
            string name = string.Format("__substg1.0_{0:X4}{1:X4}", entry.PropertyTag.ID, (short)entry.PropertyTag.Type);
            if (storage == null)
                stream = _compoundFile.RootStorage.GetStream(name);
            else
                stream = _compoundFile.RootStorage.GetStorage(storage).GetStream(name);
            switch (entry.PropertyTag.Type)
            {
                case PropertyType.PtypString:
                    obj = Encoding.Unicode.GetString(stream.GetData());
                    break;
                case PropertyType.PtypString8:
                    //No clue what to do with this one...
                    obj = null;
                    break;
                case PropertyType.PtypBinary:
                    obj = stream.GetData(); //binary data. Just return as-is. May be in the following format: https://msdn.microsoft.com/en-us/library/dd947045(v=office.12).aspx
                    break;
                case PropertyType.PtypGuid:
                    obj = new Guid(stream.GetData());
                    break;
                case PropertyType.PtypObject:
                //See https://msdn.microsoft.com/en-us/library/ee200950(v=exchg.80).aspx
                //Drink lots!
                default:
                    obj = null;
                    break;
            }
            return obj;
        }
    }
}
