using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG.Properties;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// This class will map property types to .Net types
    /// </summary>
    class TypeMapper
    {
        internal static bool IsFixedLength(PropertyType tag)
        {
            var fixedTags = new PropertyType[] {
                PropertyType.PtypInteger16,
                PropertyType.PtypInteger32,
                PropertyType.PtypInteger64,
                PropertyType.PtypFloating32,
                PropertyType.PtypFloating64,
                PropertyType.PtypBoolean,
                PropertyType.PtypCurrency,
                PropertyType.PtypFloatingTime,
                PropertyType.PtypTime,
                PropertyType.PtypErrorCode
            };
            return fixedTags.Contains(tag);
        }

        internal static object ParseEntry(PropertyEntry entry)
        {
            object obj = null;
            if (IsFixedLength(entry.PropertyTag.Type))
            {
                switch (entry.PropertyTag.Type)
                {
                    //ints
                    case PropertyType.PtypInteger16:
                        obj = BitConverter.ToInt16(entry.Value, 0);
                        break;
                    case PropertyType.PtypInteger32:
                    case PropertyType.PtypErrorCode:
                        obj = BitConverter.ToInt32(entry.Value, 0);
                        break;
                    case PropertyType.PtypInteger64:
                    case PropertyType.PtypCurrency:
                        obj = BitConverter.ToInt64(entry.Value, 0);
                        break;
                    //floats
                    case PropertyType.PtypFloating32:
                        obj = BitConverter.ToSingle(entry.Value, 0);
                        break;
                    case PropertyType.PtypFloating64:
                        //case PropertyType.PtypFloatingTime:
                        obj = BitConverter.ToDouble(entry.Value, 0);
                        break;
                    //other
                    case PropertyType.PtypBoolean:
                        obj = BitConverter.ToBoolean(entry.Value, 0);
                        break;
                    //PtypTime - 8 bytes; a 64-bit integer representing the number of 100-nanosecond intervals since January 1, 1601
                    case PropertyType.PtypTime:
                        DateTime dt = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        obj = dt.AddTicks(BitConverter.ToInt64(entry.Value, 0));
                        break;
                    default:
                        return null;
                }
            }
            return obj;
        }

        internal static byte[] ObjectToByteArray(object data)
        {
            //This is gonna be ugly...
            if (data.GetType() == typeof(int))
            {
                return BitConverter.GetBytes((int)data);
            }
            if (data.GetType() == typeof(long))
            {
                return BitConverter.GetBytes((long)data);
            }
            return null;
        }
    }
}
