#include "StdAfx.h"
#include "pst.h"
#include "TableRow.h"

#include "..\object\HnidStreamDevice.h"

using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace System::Reflection;

using namespace pstsdk::definition::ndb::node;
using namespace pstsdk::definition::util::primitives;
using namespace pstsdk::definition::ltp::table;

using namespace pstsdk::mcpp::ltp;
using namespace pstsdk::mcpp::ltp::object;
using namespace pstsdk::mcpp::ltp::table;
using namespace pstsdk::mcpp::util::prop;

namespace pstsdk { namespace mcpp { namespace ltp { namespace table 
{ 
    TableRow::TableRow(pstsdk::table table, ulong position, shared_db_ptr pst)
        : _pst(new shared_db_ptr(pst)),
          _parentTable(new pstsdk::table(table)), 
          _rowId(position)
    {
        try
        {
            pstsdk::const_table_row row = table[position];
            _row = new pstsdk::const_table_row(row);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {			
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing TableRow instance", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing TableRow instance");
        }
    }

    NodeID TableRow::Node::get()
    {
        try
        {
            return _row->get_row_id();
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {			
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving NodeId", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving NodeId");
        }
    }

    IEnumerable<PropId>^ TableRow::Properties::get()
    {
        try
        {
            std::vector<pstsdk::prop_id> properties = _row->get_prop_list();
            List<PropId>^ propList = gcnew List<PropId>();
            unsigned int i;
            for(i = 0; i < properties.size(); i++)
            {
                propList->Add((PropId)properties[i]);
                //propList->Add(gcnew util::primitives::PropId(properties[i]));
            }
            
            return propList;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {			
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving Properties", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving Properties");
        }
    }
    PropertyType TableRow::GetPropertyType(PropId id)
    {
        try
        {
            return (ushort)_row->get_prop_type(id);
            //return gcnew util::primitives::PropertyType(_table->get_prop_type(id->PropID));
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error getting Property Type", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error getting Property Type");
        }
    }

    bool TableRow::PropertyExists(PropId id)
    {
        try
        {
            return _row->prop_exists(id);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error determining if property exists", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error determining if property exists");
        }
    }

    unsigned int TableRow::PropertySize(PropId id)
    {
        try
        {
            //Propbag max non-streamable PC property size is 4 bytes
            prop_type pt = _row->get_prop_type(id);
            if(pt == prop_type_short || 
               pt == prop_type_long ||
               pt == prop_type_float ||
               pt == prop_type_error ||
               pt == prop_type_boolean)
            {
                return PropertyHelper::GetSizeFromType(pt);
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
                return _row->size(id);
            }
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property size", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property size");
        }
    }

    array<Byte>^ TableRow::ReadProperty(PropId id)
    {
        char* bytes = nullptr;
        try
        {
            pstsdk::prop_type pt = _row->get_prop_type(id);

            if(pt == prop_type_boolean)
            {
                return BitConverter::GetBytes(_row->read_prop<bool>(id));
            }
            else if(pt == prop_type_short)	//2 bytes
            {
                return BitConverter::GetBytes(_row->read_prop<short>(id));
            }
            else if (pt == prop_type_long ||
                     pt == prop_type_float || 
                     pt == prop_type_error) //4 bytes
            {
                return BitConverter::GetBytes(_row->read_prop<long>(id));
            }
            else if (pt == prop_type_null || pt == prop_type_unspecified)
            {
                throw gcnew System::InvalidOperationException("Cannot read property of this type!");
            }
            else
            {
                //byte count of property
                int propSize = _row->size(id);

                //allocate our byte array and get the property stream
                bytes = new char[propSize];
                pstsdk::hnid_stream_device stream = _row->open_prop_stream(id);

                //read the property bytes into our array
                stream.read(bytes, propSize);

                //Create our managed byte array and marshal the native array into it
                array<System::Byte>^ managedBytes = gcnew array<System::Byte>(propSize);
                Marshal::Copy(IntPtr(const_cast<void*>(static_cast<const void*>(bytes))), 
                    managedBytes, 0, propSize);

                return managedBytes;
            }
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property array", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error retrieving property array");
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

    Stream^ TableRow::OpenPropertyStream(PropId id)
    {
        return gcnew HnidStreamDevice(this, id);
    }

    shared_db_ptr TableRow::GetDBHandle()
    {
        return *_pst;
    }

    pstsdk::table* TableRow::GetParentTable()
    {
        return _parentTable.get();
    }

    ulong TableRow::GetRowId()
    {
        return _rowId;
    }
}}}}