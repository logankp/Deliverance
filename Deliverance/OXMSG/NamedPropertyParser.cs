using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenMcdf;

namespace Deliverance.OXMSG.Properties
{
    /// <summary>
    /// [MS-OXMSG] 2.2.3
    /// Storage name: __nameid_version1.0
    /// </summary>
    class NamedPropertyParser
    {
        internal const string STORAGE_NAME = "__nameid_version1.0";
        internal const string GUID_STREAM = "__substg1.0_00020102";
        internal const string STRING_STREAM = "__substg1.0_00040102";

        CompoundFile _compoundFile;
        internal NamedPropertyParser(CompoundFile cf)
        {
            _compoundFile = cf;
        }
        //GUID Stream
        internal List<Guid> Guids { get { return ReadGUIDStream(); } }
        //Entry Stream
        internal List<EntryStreamData> Entries { get { return ReadEntryStream(); } }

        /// <summary>
        /// Read the GUID stream and store each GUID in a list
        /// </summary>
        /// <returns></returns>
        private List<Guid> ReadGUIDStream()
        {
            List<Guid> guids = new List<Guid>();
            CFStream guidStream = _compoundFile.RootStorage.GetStorage(STORAGE_NAME).GetStream(GUID_STREAM);
            byte[] data = guidStream.GetData();
            int numberOfGuids = data.Length / 16;
            for (int i = 0; i < numberOfGuids; i++)
            {
                Guid guid = new Guid(data.Skip(i * 16).Take(16).ToArray());
                guids.Add(guid);
            }
            return guids;
        }

        /// <summary>
        /// Read each entry in the Entry Stream
        /// </summary>
        /// <returns></returns>
        private List<EntryStreamData> ReadEntryStream()
        {
            List<EntryStreamData> entries = new List<EntryStreamData>();
            CFStream entryStream = _compoundFile.RootStorage.GetStorage(STORAGE_NAME).GetStream(EntryStreamData.STREAM_NAME);
            byte[] data = entryStream.GetData();
            int numberOfEntries = data.Length / 8;
            for (int i = 0; i < numberOfEntries; i++)
            {
                EntryStreamData es = new EntryStreamData();
                es.NameIdentifier = BitConverter.ToInt32(data, i * 8);
                es.GUIDIndex = BitConverter.ToInt16(data, (i * 8) + 4);
                es.PropertyIndex = BitConverter.ToInt16(data, (i * 8) + 6);
                es.IsString = es.GUIDIndex % 2 == 1; //is a string
                es.GUIDIndex = (short)(es.GUIDIndex >> 1); //cut off the last bit
                entries.Add(es);
            }
            return entries;
        }

        /// <summary>
        /// Read a string from a starting offset
        /// </summary>
        /// <returns></returns>
        internal string ReadStringStream(int offset)
        {
            string propName = "";
            CFStream guidStream = _compoundFile.RootStorage.GetStorage(STORAGE_NAME).GetStream(STRING_STREAM);
            byte[] data = guidStream.GetData();
            int pos = offset;
            int length = BitConverter.ToInt32(data, pos);
            pos += 4;
            string name = Encoding.Unicode.GetString(data.Skip(pos).Take(length).ToArray());
            propName = name;
            return propName;
        }
    }
}
