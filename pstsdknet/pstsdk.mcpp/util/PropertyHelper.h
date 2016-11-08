#pragma once

#include "StdAfx.h"
#include "pst.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

using namespace pstsdk;
using namespace pstsdk::definition::util::primitives;

namespace pstsdk { namespace mcpp { namespace util { namespace prop
{
    public ref class PropertyHelper abstract sealed
    {
    public:
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an Int16.  Checks the byte count 
        ///      for a length greater than 2 bytes.
        ///   </para>
        ///   <para>For use with the <c>PtypInteger16 (0x0002)</c> property type</para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleInt16Property if you're working with a property that 
        ///   contains more than 1 Int16.
        ///</remarks>
        ///<seealso name="GetMultipleInt16Property"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static Int16 GetInt16Property(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an Int32.  Checks the byte count 
        ///      for a length greater than 4 bytes.
        ///   </para>
        ///   <para>
        ///      For use with the <c>PtypInteger32 (0x0003)</c> or <c>PtypErrorCode (0x000A)</c> 
        ///      property types
        ///   </para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleInt32Property if you're working with a property that 
        ///   contains more than 1 Int32.
        ///</remarks>
        ///<seealso name="GetMultipleInt32Property"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static Int32 GetInt32Property(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an float32 (Single).  Checks the byte count 
        ///      for a length greater than 4 bytes.
        ///   </para>
        ///   <para>
        ///      For use with the <c>PtypFloating32 (0x0004)</c> property type.
        ///   </para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleFloatProperty if you're working with a property that 
        ///   contains more than 1 float32.
        ///</remarks>
        ///<seealso name="GetMultipleFloatProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static Single GetFloatProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an float64 (Double).  Checks the byte count 
        ///      for a length greater than 8 bytes.
        ///   </para>
        ///   <para>
        ///      For use with the <c>PtypFloating64 (0x0005)</c> or <c>PtypCurrency (0x0006)</c> 
        ///      property type.
        ///   </para>
        ///</summary>
        ///<remarks>
        ///   <para>
        ///      Use GetMultipleDoubleProperty if you're working with a property that 
        ///      contains more than 1 float64.
        ///   </para>
        ///   <para>
        ///      .Net has no public Currency type.  However, the definition of the property type
        ///      PtypCurrency shows it's a [MS-DTYP] of LONGLONG or [MS-OAUT] of currency defined
        ///      as an 8 byte representation of a decimal value.  The .Net framework's decimal value
        ///      is a 128-bit type, so a Double was chosen as the closest replacement.
        ///   </para>
        ///</remarks>
        ///<seealso name="GetMultipleDoubleProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static Double GetDoubleProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to a DateTime.  Checks the byte count 
        ///      for a length greater than 8 bytes.
        ///   </para>
        ///   <para>For use with the <c>PtypFloatingTime (0x0007)</c> property type</para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleFloatingTimeProperty if you're working with a property that 
        ///   contains more than 1 DateTime.  This property is stored as a Double, representing
        ///   the number of days since December 30, 1899, the fractional part representing a fraction
        ///   of a day since midnight.
        ///   <note type="caution">
        ///      This should not be confused with <see cref="GetTimeProperty"/>.
        ///      GetTimeProperty stores it in UTC format and is not compatible with this function.
        ///   </note>
        ///</remarks>
        ///<seealso name="GetMultipleFloatingTimeProperty"/>
        ///<seealso name="GetTimeProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static DateTime GetFloatingTimeProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to a Int64.  Checks the byte count 
        ///      for a length greater than 8 bytes.
        ///   </para>
        ///   <para>For use with the <c>PtypInteger64 (0x0014)</c> property type</para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleInt64Property if you're working with a property that 
        ///   contains more than 1 Int64.
        ///</remarks>
        ///<seealso name="GetMultipleInt64Property"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static Int64 GetInt64Property(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to a unicode string.  
        ///   </para>
        ///   <para>For use with the <c>PtypString (0x001F)</c> property type</para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleUnicodeStringProperty if you're working with a property that 
        ///   is an array of unicode strings.
        ///</remarks>
        ///<seealso name="GetMultipleUnicodeStringProperty"/>
        ///<seealso name="GetEncodedStringProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static String^ GetUnicodeStringProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to a string with the specified encoding.  
        ///   </para>
        ///   <para>For use with the <c>PtypString8 (0x001E)</c> property type</para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleEncodedStringProperty if you're working with a property that 
        ///   is an array of strings encoded wiht a specified encoding.
        ///</remarks>
        ///<seealso name="GetMultipleEncodedStringProperty"/>
        ///<seealso name="GetUnicodeStringProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        ///<param name="encoding">The encoding of the string to conver the bytes to</param>
        static String^ GetEncodedStringProperty(array<Byte>^ propertyBytes, System::Text::Encoding^ encoding);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to a DateTime Structure.  
        ///   </para>
        ///   <para>For use with the <c>PtypTime (0x0040)</c> property type</para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleTimeProperty if you're working with a property that 
        ///   is an array of unicode strings.
        ///   <note type="caution">
        ///      This should not be confused with <see cref="GetFloatingTimeProperty"/>.
        ///      This function uses data stored in UTC time, whereas GetFloatingTimeProperty stores it
        ///      in a non-compatible floating point value.
        ///   </note>
        ///</remarks>
        ///<seealso name="GetMultipleTimeProperty"/>
        ///<seealso name="GetFloatingTimeProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static DateTime GetTimeProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to a Guid.  Checks the byte count 
        ///      for a length greater than 16 bytes.
        ///   </para>
        ///   <para>For use with the <c>PtypGuid (0x0048)</c> property type</para>
        ///</summary>
        ///<remarks>
        ///   Use GetMultipleGuidProperty if you're working with a property that 
        ///   contains more than 1 Guid.
        ///</remarks>
        ///<seealso name="GetMultipleGuidProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static Guid GetGuidProperty(array<Byte>^ propertyBytes);
        
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of Int16.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleInteger16 (0x1002)</c> property type</para>
        ///</summary>
        ///<seealso name="GetInt16Property"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<Int16>^ GetMultipleInt16Property(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of Int32.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleInteger32 (0x1003)</c> property type</para>
        ///</summary>
        ///<seealso name="GetInt32Property"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<Int32>^ GetMultipleInt32Property(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of float32 (Single).
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleFloating32 (0x1004)</c> property type</para>
        ///</summary>
        ///<seealso name="GetFloatProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<Single>^ GetMultipleFloatProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of float64 (Double).
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleFloating64 (0x1005)</c> property type</para>
        ///</summary>
        ///<seealso name="GetDoubleProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<Double>^ GetMultipleDoubleProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of DateTime.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleFloatingTime (0x1007)</c> property type</para>
        ///</summary>
        ///<seealso name="GetFloatingTimeProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<DateTime>^ GetMultipleFloatingTimeProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of Int64.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleInteger64 (0x1014)</c> property type</para>
        ///</summary>
        ///<seealso name="GetInt64Property"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<Int64>^ GetMultipleInt64Property(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of unicode Strings.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleString (0x101F)</c> property type</para>
        ///</summary>
        ///<seealso name="GetUnicodeStringProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<String^>^ GetMultipleUnicodeStringProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of strings with a specified encoding.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleString8 (0x101E)</c> property type</para>
        ///</summary>
        ///<seealso name="GetEncodedStringProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<String^>^ GetMultipleEncodedStringProperty(array<Byte>^ propertyBytes, System::Text::Encoding^ encoding);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of DateTime.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleTime (0x1040)</c> property type</para>
        ///</summary>
        ///<seealso name="GetTimeProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<DateTime>^ GetMultipleTimeProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of Guid.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleGuid (0x1048)</c> property type</para>
        ///</summary>
        ///<seealso name="GetGuidProperty"/>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<Guid>^ GetMultipleGuidProperty(array<Byte>^ propertyBytes);
        ///<summary>
        ///   <para>
        ///      Converts an array of bytes to an array of byte arrays.
        ///   </para>
        ///   <para>For use with the <c>PtypMultipleBinary (0x1102)</c> property type</para>
        ///</summary>
        ///<param name="propertyBytes">array of bytes representing property data</param>
        static array<array<Byte>^>^ GetMultipleBinaryProperty(array<Byte>^ propertyBytes);

    internal:
        static List<PropId>^ GetProperties(pstsdk::property_bag bag);
        static PropertyType GetPropertyType(pstsdk::property_bag bag, PropId id);
        static bool PropertyExists(pstsdk::property_bag bag, PropId id);
        static unsigned int PropertySize(pstsdk::property_bag bag, PropId id);
        static array<Byte>^ ReadProperty(pstsdk::property_bag bag, PropId id);

        static unsigned int GetSizeFromType(prop_type pt);

        static List<PropId>^ GetProperties(pstsdk::const_table_row row);
        static PropertyType GetPropertyType(pstsdk::const_table_row row, PropId id);
        static bool PropertyExists(pstsdk::const_table_row row, PropId id);
        static unsigned int PropertySize(pstsdk::const_table_row row, PropId id);
        static array<Byte>^ ReadProperty(pstsdk::const_table_row row, PropId id);
    };
}}}}