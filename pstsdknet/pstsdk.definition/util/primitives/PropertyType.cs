using System;

namespace pstsdk.definition.util.primitives
{
    public struct PropertyType : IComparable<PropertyType>, IComparable<UInt16>, IComparable<PropertyType.KnownValue>
    {
        public UInt16 Value { get; set; }

        public static implicit operator PropertyType(UInt16 value)
        {
            return new PropertyType { Value = value };
        }

        public static implicit operator KnownValue(PropertyType value)
        {
            return (KnownValue)value.Value;
        }

        public static implicit operator PropertyType(KnownValue value)
        {
            return (ushort)value;
        }

        public static implicit operator UInt16(PropertyType value)
        {
            return value.Value;
        }

        public int CompareTo(PropertyType other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(ushort other)
        {
            return Value.CompareTo(other);
        }

        public int CompareTo(KnownValue other)
        {
            return Value.CompareTo(other);
        }

        /// <summary>
        /// The different property types as defined by MAPI, [MS-OXCDATA] 2.12.1
        /// </summary>
        public enum KnownValue : ushort
        {
            prop_type_unspecified = 0,
            prop_type_null = 1,
            prop_type_short = 2,
            prop_type_mv_short = 4098,
            prop_type_long = 3,
            prop_type_mv_long = 4099,
            prop_type_float = 4,
            prop_type_mv_float = 4100,
            prop_type_double = 5,
            prop_type_mv_double = 4101,
            prop_type_currency = 6,
            prop_type_mv_currency = 4102,
            prop_type_apptime = 7,          //!< VT_DATE
            prop_type_mv_apptime = 4103,
            prop_type_error = 10,
            prop_type_boolean = 11,
            prop_type_object = 13,
            prop_type_longlong = 20,
            prop_type_mv_longlong = 4116,
            prop_type_string = 30,
            prop_type_mv_string = 4126,
            prop_type_wstring = 31,
            prop_type_mv_wstring = 4127,
            prop_type_systime = 64,         //!< Win32 FILETIME
            prop_type_mv_systime = 4160,
            prop_type_guid = 72,
            prop_type_mv_guid = 4168,
            prop_type_binary = 258,
            prop_type_mv_binary = 4354,
        }
    }
}