<?xml version="1.0"?><doc>
<members>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetInt16Property(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="18">
<summary>
  <para>
     Converts an array of bytes to an Int16.  Checks the byte count 
     for a length greater than 2 bytes.
  </para>
  <para>For use with the <c>PtypInteger16 (0x0002)</c> property type</para>
</summary>
<remarks>
  Use GetMultipleInt16Property if you're working with a property that 
  contains more than 1 Int16.
</remarks>
<seealso name="GetMultipleInt16Property"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetInt32Property(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="32">
<summary>
  <para>
     Converts an array of bytes to an Int32.  Checks the byte count 
     for a length greater than 4 bytes.
  </para>
  <para>
     For use with the <c>PtypInteger32 (0x0003)</c> or <c>PtypErrorCode (0x000A)</c> 
     property types
  </para>
</summary>
<remarks>
  Use GetMultipleInt32Property if you're working with a property that 
  contains more than 1 Int32.
</remarks>
<seealso name="GetMultipleInt32Property"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetFloatProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="49">
<summary>
  <para>
     Converts an array of bytes to an float32 (Single).  Checks the byte count 
     for a length greater than 4 bytes.
  </para>
  <para>
     For use with the <c>PtypFloating32 (0x0004)</c> property type.
  </para>
</summary>
<remarks>
  Use GetMultipleFloatProperty if you're working with a property that 
  contains more than 1 float32.
</remarks>
<seealso name="GetMultipleFloatProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetDoubleProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="65">
<summary>
  <para>
     Converts an array of bytes to an float64 (Double).  Checks the byte count 
     for a length greater than 8 bytes.
  </para>
  <para>
     For use with the <c>PtypFloating64 (0x0005)</c> or <c>PtypCurrency (0x0006)</c> 
     property type.
  </para>
</summary>
<remarks>
  <para>
     Use GetMultipleDoubleProperty if you're working with a property that 
     contains more than 1 float64.
  </para>
  <para>
     .Net has no public Currency type.  However, the definition of the property type
     PtypCurrency shows it's a [MS-DTYP] of LONGLONG or [MS-OAUT] of currency defined
     as an 8 byte representation of a decimal value.  The .Net framework's decimal value
     is a 128-bit type, so a Double was chosen as the closest replacement.
  </para>
</remarks>
<seealso name="GetMultipleDoubleProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetFloatingTimeProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="90">
<summary>
  <para>
     Converts an array of bytes to a DateTime.  Checks the byte count 
     for a length greater than 8 bytes.
  </para>
  <para>For use with the <c>PtypFloatingTime (0x0007)</c> property type</para>
</summary>
<remarks>
  Use GetMultipleFloatingTimeProperty if you're working with a property that 
  contains more than 1 DateTime.  This property is stored as a Double, representing
  the number of days since December 30, 1899, the fractional part representing a fraction
  of a day since midnight.
  <note type="caution">
     This should not be confused with <see cref="M:pstsdk.mcpp.util.prop.PropertyHelper.GetTimeProperty(System.Byte[])"/>.
     GetTimeProperty stores it in UTC format and is not compatible with this function.
  </note>
</remarks>
<seealso name="GetMultipleFloatingTimeProperty"/>
<seealso name="GetTimeProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetInt64Property(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="111">
<summary>
  <para>
     Converts an array of bytes to a Int64.  Checks the byte count 
     for a length greater than 8 bytes.
  </para>
  <para>For use with the <c>PtypInteger64 (0x0014)</c> property type</para>
</summary>
<remarks>
  Use GetMultipleInt64Property if you're working with a property that 
  contains more than 1 Int64.
</remarks>
<seealso name="GetMultipleInt64Property"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetUnicodeStringProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="125">
<summary>
  <para>
     Converts an array of bytes to a unicode string.  
  </para>
  <para>For use with the <c>PtypString (0x001F)</c> property type</para>
</summary>
<remarks>
  Use GetMultipleUnicodeStringProperty if you're working with a property that 
  is an array of unicode strings.
</remarks>
<seealso name="GetMultipleUnicodeStringProperty"/>
<seealso name="GetEncodedStringProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetEncodedStringProperty(System.Byte[],System.Text.Encoding)" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="139">
<summary>
  <para>
     Converts an array of bytes to a string with the specified encoding.  
  </para>
  <para>For use with the <c>PtypString8 (0x001E)</c> property type</para>
</summary>
<remarks>
  Use GetMultipleEncodedStringProperty if you're working with a property that 
  is an array of strings encoded wiht a specified encoding.
</remarks>
<seealso name="GetMultipleEncodedStringProperty"/>
<seealso name="GetUnicodeStringProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
<param name="encoding">The encoding of the string to conver the bytes to</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetTimeProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="154">
<summary>
  <para>
     Converts an array of bytes to a DateTime Structure.  
  </para>
  <para>For use with the <c>PtypTime (0x0040)</c> property type</para>
</summary>
<remarks>
  Use GetMultipleTimeProperty if you're working with a property that 
  is an array of unicode strings.
  <note type="caution">
     This should not be confused with <see cref="M:pstsdk.mcpp.util.prop.PropertyHelper.GetFloatingTimeProperty(System.Byte[])"/>.
     This function uses data stored in UTC time, whereas GetFloatingTimeProperty stores it
     in a non-compatible floating point value.
  </note>
</remarks>
<seealso name="GetMultipleTimeProperty"/>
<seealso name="GetFloatingTimeProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetGuidProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="173">
<summary>
  <para>
     Converts an array of bytes to a Guid.  Checks the byte count 
     for a length greater than 16 bytes.
  </para>
  <para>For use with the <c>PtypGuid (0x0048)</c> property type</para>
</summary>
<remarks>
  Use GetMultipleGuidProperty if you're working with a property that 
  contains more than 1 Guid.
</remarks>
<seealso name="GetMultipleGuidProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleInt16Property(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="188">
<summary>
  <para>
     Converts an array of bytes to an array of Int16.
  </para>
  <para>For use with the <c>PtypMultipleInteger16 (0x1002)</c> property type</para>
</summary>
<seealso name="GetInt16Property"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleInt32Property(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="197">
<summary>
  <para>
     Converts an array of bytes to an array of Int32.
  </para>
  <para>For use with the <c>PtypMultipleInteger32 (0x1003)</c> property type</para>
</summary>
<seealso name="GetInt32Property"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleFloatProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="206">
<summary>
  <para>
     Converts an array of bytes to an array of float32 (Single).
  </para>
  <para>For use with the <c>PtypMultipleFloating32 (0x1004)</c> property type</para>
</summary>
<seealso name="GetFloatProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleDoubleProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="215">
<summary>
  <para>
     Converts an array of bytes to an array of float64 (Double).
  </para>
  <para>For use with the <c>PtypMultipleFloating64 (0x1005)</c> property type</para>
</summary>
<seealso name="GetDoubleProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleFloatingTimeProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="224">
<summary>
  <para>
     Converts an array of bytes to an array of DateTime.
  </para>
  <para>For use with the <c>PtypMultipleFloatingTime (0x1007)</c> property type</para>
</summary>
<seealso name="GetFloatingTimeProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleInt64Property(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="233">
<summary>
  <para>
     Converts an array of bytes to an array of Int64.
  </para>
  <para>For use with the <c>PtypMultipleInteger64 (0x1014)</c> property type</para>
</summary>
<seealso name="GetInt64Property"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleUnicodeStringProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="242">
<summary>
  <para>
     Converts an array of bytes to an array of unicode Strings.
  </para>
  <para>For use with the <c>PtypMultipleString (0x101F)</c> property type</para>
</summary>
<seealso name="GetUnicodeStringProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleEncodedStringProperty(System.Byte[],System.Text.Encoding)" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="251">
<summary>
  <para>
     Converts an array of bytes to an array of strings with a specified encoding.
  </para>
  <para>For use with the <c>PtypMultipleString8 (0x101E)</c> property type</para>
</summary>
<seealso name="GetEncodedStringProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleTimeProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="260">
<summary>
  <para>
     Converts an array of bytes to an array of DateTime.
  </para>
  <para>For use with the <c>PtypMultipleTime (0x1040)</c> property type</para>
</summary>
<seealso name="GetTimeProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleGuidProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="269">
<summary>
  <para>
     Converts an array of bytes to an array of Guid.
  </para>
  <para>For use with the <c>PtypMultipleGuid (0x1048)</c> property type</para>
</summary>
<seealso name="GetGuidProperty"/>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
<member name="M:pstsdk.mcpp.util.prop.PropertyHelper.GetMultipleBinaryProperty(System.Byte[])" decl="true" source="d:\work\mailbird\tests\pstsdknet\pstsdknet\pstsdk.mcpp\util\propertyhelper.h" line="278">
<summary>
  <para>
     Converts an array of bytes to an array of byte arrays.
  </para>
  <para>For use with the <c>PtypMultipleBinary (0x1102)</c> property type</para>
</summary>
<param name="propertyBytes">array of bytes representing property data</param>
</member>
</members>
</doc>