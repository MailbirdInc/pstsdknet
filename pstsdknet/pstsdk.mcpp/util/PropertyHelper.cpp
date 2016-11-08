#include "StdAfx.h"
#include "pst.h"
#include "util\primitives.h"
#include "PropertyHelper.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

using namespace pstsdk;
using namespace pstsdk::mcpp::util::prop;
using namespace pstsdk::definition::util::primitives;

namespace pstsdk { namespace mcpp { namespace util { namespace prop
{
	Int16 PropertyHelper::GetInt16Property(array<Byte>^ propertyBytes)
	{ 
		if(propertyBytes->Length == 2)
		{
			return BitConverter::ToInt16(propertyBytes, 0);
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	Int32 PropertyHelper::GetInt32Property(array<Byte>^ propertyBytes)
	{
		if(propertyBytes->Length == 4)
		{
			return BitConverter::ToInt32(propertyBytes, 0);
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	Single PropertyHelper::GetFloatProperty(array<Byte>^ propertyBytes)
	{ 
		if(propertyBytes->Length == 4)
		{
			return BitConverter::ToSingle(propertyBytes, 0);
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	Double PropertyHelper::GetDoubleProperty(array<Byte>^ propertyBytes)
	{
		if(propertyBytes->Length == 8)
		{
			return BitConverter::ToDouble(propertyBytes, 0);
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	DateTime PropertyHelper::GetFloatingTimeProperty(array<Byte>^ propertyBytes)
	{
		return DateTime::FromOADate(PropertyHelper::GetDoubleProperty(propertyBytes));
	}
	Int64 PropertyHelper::GetInt64Property(array<Byte>^ propertyBytes)
	{
		if(propertyBytes->Length == 8)
		{
			return BitConverter::ToInt64(propertyBytes, 0);
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	String^ PropertyHelper::GetUnicodeStringProperty(array<Byte>^ propertyBytes)
	{
		System::Text::UnicodeEncoding enc;
		return enc.GetString(propertyBytes, 0, propertyBytes->Length);
	}
	String^ PropertyHelper::GetEncodedStringProperty(array<Byte>^ propertyBytes, System::Text::Encoding^ encoding)
	{
		return encoding->GetString(propertyBytes);
	}
	DateTime PropertyHelper::GetTimeProperty(array<Byte>^ propertyBytes)
	{
		if(propertyBytes->Length == 8)
		{
			return DateTime::FromFileTime(PropertyHelper::GetInt64Property(propertyBytes));
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	//DateTime^ time_tToSystemDateTime(time_t tt)
	//{
	//	tm* timeptr = gmtime(&tt);
	//	DateTime^ sdt(timeptr->tm_year + 1900,
	//	timeptr->tm_mon + 1,
	//	timeptr->tm_mday,
	//	timeptr->tm_hour,
	//	timeptr->tm_min,
	//	timeptr->tm_sec);
	//	return sdt;
	//}
	Guid PropertyHelper::GetGuidProperty(array<Byte>^ propertyBytes)
	{
		if(propertyBytes->Length == 16)
		{
			array<Byte>^ lastEightBytes = gcnew array<Byte>(8);
			Array::Copy(propertyBytes, 8, lastEightBytes, 0, 8);

			return System::Guid(
				BitConverter::ToInt32(propertyBytes, 0),
				BitConverter::ToInt16(propertyBytes, 4),
				BitConverter::ToInt16(propertyBytes, 6),
				lastEightBytes);
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}

	array<Int16>^ PropertyHelper::GetMultipleInt16Property(array<Byte>^ propertyBytes)
	{
		if((propertyBytes->Length - 2) % 2 == 0)
		{
			int i;
			int currentPos = 0;
			int valueSize = 2;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<Int16>^ arr = gcnew array<Int16>(count);
			currentPos += 2;

			for(i = 0; i < count; i++, currentPos + valueSize)
			{
				arr[i] = BitConverter::ToInt16(propertyBytes, currentPos);
			}

			return arr;
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	array<Int32>^ PropertyHelper::GetMultipleInt32Property(array<Byte>^ propertyBytes)
	{
		if((propertyBytes->Length - 2) % 4 == 0)
		{
			int i;
			int currentPos = 0;
			int valueSize = 4;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<Int32>^ arr = gcnew array<Int32>(count);
			currentPos += 2;

			for(i = 0; i < count; i++, currentPos + valueSize)
			{
				arr[i] = BitConverter::ToInt32(propertyBytes, currentPos);
			}

			return arr;
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	array<Single>^ PropertyHelper::GetMultipleFloatProperty(array<Byte>^ propertyBytes)
	{
		if((propertyBytes->Length - 2) % 8 == 0)
		{
			int i;
			int currentPos = 0;
			int valueSize = 4;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<Single>^ arr = gcnew array<Single>(count);
			currentPos += 2;

			for(i = 0; i < count; i++, currentPos + valueSize)
			{
				arr[i] = BitConverter::ToSingle(propertyBytes, currentPos);
			}

			return arr;
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	array<Double>^ PropertyHelper::GetMultipleDoubleProperty(array<Byte>^ propertyBytes)
	{
		if((propertyBytes->Length - 2) % 8 == 0)
		{
			int i;
			int currentPos = 0;
			int valueSize = 8;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<Double>^ arr = gcnew array<Double>(count);
			currentPos += 2;

			for(i = 0; i < count; i++, currentPos + valueSize)
			{
				arr[i] = BitConverter::ToDouble(propertyBytes, currentPos);
			}

			return arr;
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}

	}
	array<DateTime>^ PropertyHelper::GetMultipleFloatingTimeProperty(array<Byte>^ propertyBytes)
	{
		if((propertyBytes->Length - 2) % 8 == 0)
		{
			int i;
			int currentPos = 0;
			int valueSize = 8;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<DateTime>^ arr = gcnew array<DateTime>(count);
			currentPos += 2;

			for(i = 0; i < count; i++, currentPos + valueSize)
			{
				arr[i] = DateTime::FromOADate(BitConverter::ToDouble(propertyBytes, currentPos));
			}

			return arr;
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	array<Int64>^ PropertyHelper::GetMultipleInt64Property(array<Byte>^ propertyBytes)
	{ 
		if((propertyBytes->Length - 2) % 8 == 0)
		{
			int i;
			int currentPos = 0;
			int valueSize = 8;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<Int64>^ arr = gcnew array<Int64>(count);
			currentPos += 2;

			for(i = 0; i < count; i++, currentPos + valueSize)
			{
				arr[i] = BitConverter::ToInt64(propertyBytes, currentPos);
			}

			return arr;
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	array<String^>^ PropertyHelper::GetMultipleUnicodeStringProperty(array<Byte>^ propertyBytes)
	{ throw gcnew NotImplementedException(); }
	array<String^>^ PropertyHelper::GetMultipleEncodedStringProperty(array<Byte>^ propertyBytes, System::Text::Encoding^ encoding)
	{ throw gcnew NotImplementedException(); }

	array<DateTime>^ PropertyHelper::GetMultipleTimeProperty(array<Byte>^ propertyBytes)
	{
		if((propertyBytes->Length - 2) % 8 == 0)
		{
			int i;
			int currentPos = 0;
			int valueSize = 8;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<DateTime>^ arr = gcnew array<DateTime>(count);
			currentPos += 2;

			for(i = 0; i < count; i++, currentPos + valueSize)
			{
				arr[i] = DateTime::FromFileTime(BitConverter::ToInt64(propertyBytes, currentPos));
			}

			return arr;
		}
		else
		{
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	array<Guid>^ PropertyHelper::GetMultipleGuidProperty(array<Byte>^ propertyBytes)
	{
		if((propertyBytes->Length - 2) % 16 == 0)
		{
			int curPosition = 0;
			int valueSize = 16;
			int count = BitConverter::ToInt16(propertyBytes, 0);
			curPosition += 2;
			
			array<Guid>^ guids = gcnew array<Guid>(count);

			int i;
			for(i = 0; i < count; i++, curPosition + valueSize)
			{
				array<Byte>^ thisGuid = gcnew array<Byte>(16);
				Array::Copy(propertyBytes, curPosition, thisGuid, 0, 16);

				guids[i] = PropertyHelper::GetGuidProperty(thisGuid);
			}
			return nullptr;
		}
		else
		{			
			throw gcnew System::ArgumentException("Byte count mismatch to return type");
		}
	}
	array<array<Byte>^>^ PropertyHelper::GetMultipleBinaryProperty(array<Byte>^ propertyBytes)
	{
		try
		{
			int i;
			int currentPos = 0;
			int count = BitConverter::ToInt16(propertyBytes, 0);

			array<array<Byte>^>^ arr = gcnew array<array<Byte>^>(count);
			currentPos += 2;

			for(i = 0; i < count; i++)
			{
				int curArraySize = BitConverter::ToInt16(propertyBytes, currentPos);
				currentPos += 2;

				arr[i] = gcnew array<Byte>(curArraySize);
				Array::Copy(propertyBytes, currentPos, arr[i], 0, curArraySize);

				currentPos += curArraySize;
			}

			return arr;
		}
		catch (System::Exception^ ex)
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving Multiple Binary Format", ex);
		}
	}

	List<PropId>^ PropertyHelper::GetProperties(pstsdk::property_bag bag)
	{
		try
		{
			std::vector<pstsdk::prop_id> properties = bag.get_prop_list();
			List<PropId>^ propList = gcnew List<PropId>();
			unsigned int i;
			for(i = 0; i < properties.size(); i++)
			{
				propList->Add((PropId)properties[i]);
			}
			
			return propList;
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error enumerating message properties", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error enumerating message properties", ex);
		}
	}
	PropertyType PropertyHelper::GetPropertyType(pstsdk::property_bag bag, PropId id)
	{
		try
		{
			return (ushort)bag.get_prop_type(id);
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error enumerating message properties", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error enumerating message properties", ex);
		}
	}

	bool PropertyHelper::PropertyExists(pstsdk::property_bag bag, PropId id)
	{
		try
		{
			return bag.prop_exists(id);
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error determining if property exists", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error determining if property exists", ex);
		}
	}

	unsigned int PropertyHelper::GetSizeFromType(prop_type pt)
	{
		switch(pt)
		{
		case prop_type_boolean:
			return 1; break;
		case prop_type_short:
			return 2; break;
		case prop_type_long:
		case prop_type_float:
		case prop_type_error:
			return 4; break;
		case prop_type_double:
		case prop_type_currency:
		case prop_type_apptime:
		case prop_type_longlong:
		case prop_type_systime:
			return 8; break;
		default:
			return 0;
		}
	}

	unsigned int PropertyHelper::PropertySize(pstsdk::property_bag bag, PropId id)
	{
		try
		{
			//Propbag max non-streamable PC property size is 4 bytes
			prop_type pt = bag.get_prop_type(id);
			if(pt == prop_type_short || 
			   pt == prop_type_long ||
			   pt == prop_type_float ||
			   pt == prop_type_error ||
			   pt == prop_type_boolean)
			{
				return GetSizeFromType(pt);
			}
			//return empty if it's unspecified or null
			else if (pt == prop_type_unspecified ||
					 pt == prop_type_null)
			{
				return 0;
			}
			//variable size, method call is valid
			else
			{
				return bag.size(id);
			}
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error retrieving property size", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property size", ex);
		}
	}


	array<Byte>^ PropertyHelper::ReadProperty(pstsdk::property_bag bag, PropId id)
	{
		char* bytes = nullptr;
		try
		{
			pstsdk::prop_type pt = bag.get_prop_type(id);

			if(pt == prop_type_boolean)
			{
				return BitConverter::GetBytes(bag.read_prop<bool>(id));
			}
			else if(pt == prop_type_short)	//2 bytes
			{
				return BitConverter::GetBytes(bag.read_prop<short>(id));
			}
			else if (pt == prop_type_long ||
					 pt == prop_type_float || 
					 pt == prop_type_error) //4 bytes
			{
				return BitConverter::GetBytes(bag.read_prop<long>(id));
			}
			else if (pt == prop_type_null || pt == prop_type_unspecified)
			{
				throw gcnew System::InvalidOperationException("Cannot read property of this type!");
			}
			else
			{
				//byte count of property
				int propSize = bag.size(id);

				//allocate our byte array and get the property stream
				bytes = new char[propSize];
				pstsdk::hnid_stream_device stream = bag.open_prop_stream(id);

				//read the property bytes into our array
				stream.read(bytes, propSize);

				//Create our managed byte array and marshal the native array into it
				array<System::Byte>^ managedBytes = gcnew array<System::Byte>(propSize);
				Marshal::Copy(IntPtr(const_cast<void*>(static_cast<const void*>(bytes))), 
					managedBytes, 0, propSize);

				return managedBytes;
			}
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error retrieving property array", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property array", ex);
		}
		finally
		{
			if(bytes != nullptr)
			{
				//free our native bytes
				delete [] bytes;
				bytes = nullptr;
			}
		}
	}

	
	List<PropId>^ PropertyHelper::GetProperties(pstsdk::const_table_row row)
	{
		try
		{
			std::vector<pstsdk::prop_id> properties = row.get_prop_list();
			List<PropId>^ propList = gcnew List<PropId>();
			unsigned int i;
			for(i = 0; i < properties.size(); i++)
			{
				propList->Add((PropId)properties[i]);
				//propList->Add(gcnew util::primitives::PropId(properties[i]));
			}
			
			return propList;
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error enumerating message properties", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error enumerating message properties", ex);
		}
	}
	PropertyType PropertyHelper::GetPropertyType(pstsdk::const_table_row row, PropId id)
	{
		try
		{
			return (ushort)row.get_prop_type(id);
			//return gcnew util::primitives::PropertyType(row.get_prop_type(id->PropID));
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error enumerating message properties", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error enumerating message properties", ex);
		}
	}


	bool PropertyHelper::PropertyExists(pstsdk::const_table_row row, PropId id)
	{
		try
		{
			return row.prop_exists(id);
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error determining if property exists", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error determining if property exists", ex);
		}
	}

	unsigned int PropertyHelper::PropertySize(pstsdk::const_table_row row, PropId id)
	{
		try
		{
			//Propbag max non-streamable TC property size is 8 bytes
			prop_type pt = row.get_prop_type(id);
			if(pt == prop_type_short || 
			   pt == prop_type_long ||
			   pt == prop_type_float ||
			   pt == prop_type_error ||
			   pt == prop_type_double ||
			   pt == prop_type_apptime ||
			   pt == prop_type_error ||
			   pt == prop_type_boolean ||
			   pt == prop_type_longlong ||
			   pt == prop_type_systime)
			{
				return GetSizeFromType(pt);
			}
			//return empty if it's unspecified or null
			else if (pt == prop_type_unspecified ||
					 pt == prop_type_null)
			{
				return 0;
			}
			//variable size, method call is valid
			else
			{
				return row.size(id);
			}
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error retrieving property size", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property size", ex);
		}
	}

	array<Byte>^ PropertyHelper::ReadProperty(pstsdk::const_table_row row, PropId id)
	{
		char* bytes = nullptr;
		try
		{
			pstsdk::prop_type pt = row.get_prop_type(id);

			if(pt == prop_type_boolean)
			{
				return BitConverter::GetBytes(row.read_prop<bool>(id));
			}
			else if(pt == prop_type_short)	//2 bytes
			{
				return BitConverter::GetBytes(row.read_prop<short>(id));
			}
			else if (pt == prop_type_long || 
					 pt == prop_type_float || 
					 pt == prop_type_error) //4 bytes
			{
				return BitConverter::GetBytes(row.read_prop<long>(id));
			}
			else if (pt == prop_type_double || 
					 pt == prop_type_currency || 
					 pt == prop_type_apptime ||
					 pt == prop_type_longlong || 
					 pt == prop_type_systime)
			{
				return BitConverter::GetBytes(row.read_prop<__int64>(id));
			}
			else if (pt == prop_type_unspecified || pt == prop_type_null)
			{
				throw gcnew InvalidOperationException("Cannot read property of this type!");
			}
			else
			{
				//byte count of property
				int propSize = row.size(id);

				//allocate our byte array and get the property stream
				bytes = new char[propSize];
				pstsdk::hnid_stream_device stream = row.open_prop_stream(id);

				//read the property bytes into our array
				stream.read(bytes, propSize);

				//Create our managed byte array and marshal the native array into it
				array<System::Byte>^ managedBytes = gcnew array<System::Byte>(propSize);
				Marshal::Copy(IntPtr(const_cast<void*>(static_cast<const void*>(bytes))), 
					managedBytes, 0, propSize);

				return managedBytes;
			}
		}
		catch(int i) // runtime exceptions...
		{
			throw gcnew pstsdk::definition::exception::PstSdkRunTimeException(i);
		}
		catch(std::exception unmanagedEx) // standard library exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkStdLibException(gcnew String(unmanagedEx.what()) );
		}
		catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
		{
			throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error retrieving property array", sehEx);
		}
		catch(System::Exception^ ex) // .NET Managed exception 
		{
			throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property array", ex);
		}
		finally
		{
			if(bytes != nullptr)
			{
				//free our native bytes
				delete [] bytes;
				bytes = nullptr;
			}
		}
	}
}}}}