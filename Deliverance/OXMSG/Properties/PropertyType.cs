namespace Deliverance.OXMSG.Properties
{
    enum PropertyTypeAttribute
    {
        FIXED,
        VARIABLE,
        MULTI_FIXED,
        MULTI_VARIABLE
    }

    /// <summary>
    /// Property Types
    /// https://msdn.microsoft.com/en-us/library/ee157583.aspx
    /// </summary>
    enum PropertyType : short
    {
        #region Fixed Length Property types
        /// <summary>
        /// 2 bytes; a 16-bit integer
        /// </summary>
        PtypInteger16 = 0x0002,
        /// <summary>
        /// 4 bytes; a 32-bit integer
        /// </summary>
        PtypInteger32 = 0x0003,
        /// <summary>
        /// 4 bytes; a 32-bit floating point number
        /// </summary>
        PtypFloating32 = 0x0004,
        /// <summary>
        /// 8 bytes; a 64-bit floating point number
        /// </summary>
        PtypFloating64 = 0x0005,
        /// <summary>
        /// 1 byte; restricted to 1 or 0
        /// </summary>
        PtypBoolean = 0x000B,
        /// <summary>
        /// 8 bytes; a 64-bit signed, scaled integer representation of a decimal currency value, with four places to the right of the decimal point
        /// </summary>
        PtypCurrency = 0x0006,
        /// <summary>
        /// 8 bytes; a 64-bit floating point number in which the whole number part represents the number of days since December 30, 1899, and the fractional part represents the fraction of a day since midnight
        /// </summary>
        PtypFloatingTime = 0x0007,
        /// <summary>
        /// 8 bytes; a 64-bit integer representing the number of 100-nanosecond intervals since January 1, 1601
        /// </summary>
        PtypTime = 0x0040,
        /// <summary>
        /// 8 bytes; a 64-bit integer
        /// </summary>
        PtypInteger64 = 0x0014,
        /// <summary>
        /// 4 bytes; a 32-bit integer encoding error information as specified in section 2.4.1.
        /// </summary>
        PtypErrorCode = 0x000A,
        #endregion
        #region Variable Length Property types
        /// <summary>
        /// Variable size; a string of Unicode characters in UTF-16LE format encoding with terminating null character (0x0000).
        /// </summary>
        PtypString = 0x001F,
        /// <summary>
        /// Variable size; a COUNT field followed by that many bytes.
        /// </summary>
        PtypBinary = 0x0102,
        /// <summary>
        /// Variable size; a string of multibyte characters in externally specified encoding with terminating null character (single 0 byte).
        /// </summary>
        PtypString8 = 0x001E,
        /// <summary>
        /// 16 bytes; a GUID with Data1, Data2, and Data3 fields in little-endian format
        /// </summary>
        PtypGuid = 0x0048,
        /// <summary>
        /// The property value is a Component Object Model (COM) object, as specified in section 2.11.1.5.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee200950.aspx"/>
        /// </summary>
        PtypObject = 0x000D,
        #endregion
        #region Fixed Length Multiple-Valued Property types
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger16 values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleInteger16 = 0x1002,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger32 values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleInteger32 = 0x1003,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloating32 values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleFloating32 = 0x1004,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloating64 values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleFloating64 = 0x1005,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypCurrency values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleCurrency = 0x1006,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloatingTime values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleFloatingTime = 0x1007,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypTime values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleTime = 0x1040,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypGuid values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleGuid = 0x1048,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger64 values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleInteger64 = 0x1014,
        #endregion
        #region Variable Length Multiple-Valued Property types
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypBinary values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleBinary = 0x1102,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypString8 values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleString8 = 0x101E,
        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypString values.
        /// <see cref="https://msdn.microsoft.com/en-us/library/ee157583.aspx"/>
        /// </summary>
        PtypMultipleString = 0x101F
        #endregion
    }
}
