#pragma once
#include "Stdafx.h"
#include "..\propbag\PropertyBag.h"
#include "..\table\TableRow.h"
#include "HnidStreamDevice.h"
#include "..\..\ndb\context\DBAccessor.h"
#include "pst.h"

//using namespace std;

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace System::Text;

using namespace pstsdk;
using namespace pstsdk::definition::ndb::database;
using namespace pstsdk::definition::ltp::nameid;
using namespace pstsdk::definition::exception;
using namespace pstsdk::definition::util::primitives;

using namespace pstsdk::mcpp::ltp;
using namespace pstsdk::mcpp::ltp::table;
using namespace pstsdk::mcpp::ndb::database;

namespace pstsdk { namespace mcpp { namespace ltp { namespace object
{
    // TODO: Lots of duplicated code here in the constructors.  Needs fixed.
    HnidStreamDevice::HnidStreamDevice(IPropertyObject^ object, PropId propId)
    {
        try
        {
            PropertyBag^ bag = dynamic_cast<PropertyBag^>(object);
            if(bag != nullptr)
            {
                pstsdk::property_bag* propBag = bag->GetPropertyBag();
                h_id = static_cast<heapnode_id>(propBag->read_prop<ulong>(propId));
                isTable = false;

                _db = new shared_db_ptr(bag->GetDBHandle());
                SetupStream(propBag->get_node());
            }
            else
            {
                TableRow^ row = dynamic_cast<TableRow^>(object);
                if(row == nullptr)
                    throw gcnew PstSdkException("Could not cast object as IPropertyObject!");

                pstsdk::table* t = row->GetParentTable();
                h_id = static_cast<heapnode_id>(t->get_cell_value(row->GetRowId(), propId));
                isTable = true;
                
                _db = new shared_db_ptr(row->GetDBHandle());
                SetupStream(t->get_node());
            }
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing HnidStream from IPropertyObject", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing HnidStream from IPropertyObject");
        }
    }
    
    HnidStreamDevice::HnidStreamDevice(TableRow^ row, PropId propId)
    {
        try
        {
            pstsdk::table* t = row->GetParentTable();
            h_id = static_cast<heapnode_id>(t->get_cell_value(row->GetRowId(), propId));
            isTable = true;
            
            _db = new shared_db_ptr(row->GetDBHandle());
            SetupStream(t->get_node());
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing HnidStream from TableRow", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing HnidStream from TableRow");
        }
    }

    HnidStreamDevice::HnidStreamDevice(PropertyBag^ propBag, PropId propId)
    {
        try
        {
            pstsdk::property_bag* bag = propBag->GetPropertyBag();
            h_id = static_cast<heapnode_id>(bag->read_prop<ulong>(propId));
            isTable = false;

            
            _db = new shared_db_ptr(propBag->GetDBHandle());
            SetupStream(bag->get_node());
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing HnidStream from PropertyBag", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing HnidStream from PropertyBag");
        }
    }

    void HnidStreamDevice::SetupStream(pstsdk::node n)
    {		
        if(is_subnode_id(h_id) && h_id != 0)
        {
            isHeap = false;

            pstsdk::node childNode = n.lookup(h_id);

            pstsdk::node_info ni;
            ni.id = childNode.get_id();
            ni.data_bid = childNode.get_data_id();
            ni.sub_bid = childNode.get_sub_id();
            ni.parent_id = childNode.get_parent_id();

            _node = new node_impl(*_db, ni);
            _size = _node->size();
        }
        else
        {
            isHeap = true;
            _heap = isTable ? new pstsdk::heap(n, pstsdk::disk::heap_sig_tc) : 
                              new pstsdk::heap(n, pstsdk::disk::heap_sig_pc);
            _size = _heap->size(h_id);
        }
    }

    void HnidStreamDevice::Flush()
    { throw gcnew NotSupportedException(); }
    void HnidStreamDevice::SetLength(Int64 value)
    { throw gcnew NotSupportedException(); }
    void HnidStreamDevice::Write(array<byte>^ buffer, int offset, int count)
    { throw gcnew NotSupportedException(); }

    bool HnidStreamDevice::CanRead::get()
    { return true; }
    bool HnidStreamDevice::CanSeek::get()
    { return true; }
    bool HnidStreamDevice::CanWrite::get()
    { return false; }

    Int64 HnidStreamDevice::Length::get()
    {
        try
        {
            if(isHeap)
                return _heap->size(h_id);
            else
                return _node->size();
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reading Stream Length", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reading Stream Length");
        }
    }

    Int64 HnidStreamDevice::Position::get()
    {
        return _pos;
    }

    void HnidStreamDevice::Position::set(Int64 value)
    {
        Seek((int)value, SeekOrigin::Begin);
    }

    int HnidStreamDevice::ReadByte()
    {
        if(_pos > _size)
            return -1;

        char* buffer = nullptr;
        try
        {		
            if(!isHeap)
            {
                _node->read_raw(reinterpret_cast<byte*>(buffer), 1, (pstsdk::ulong)_pos);
                return *buffer;
            }
            else
            {
                std::vector<byte> buf(1);
                _heap->read(buf, h_id, 1);
                return buf[0];
            }
        }
        catch(System::Exception^ ex)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reading reading byte from Stream", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reading reading byte from Stream");
        }
        finally
        {
            if(buffer != nullptr)
                delete buffer;
        }
    }

    int HnidStreamDevice::Read(array<byte>^ buffer, int offset, int length)
    {
        if(_pos >= _size)
            return 0;

        char* pbuffer = nullptr;
        int readLength = 0;

        if((offset + length) > buffer->Length)
            throw gcnew System::ArgumentException("Offset and length greater than buffer size");

        try
        {
            pbuffer = new char[length];

            if(!isHeap)
            {
                //Read from a node
                readLength = _node->read_raw(reinterpret_cast<byte*>(pbuffer), 
                    static_cast<size_t>(length), static_cast<size_t>(_pos));

                Marshal::Copy(IntPtr(pbuffer), buffer, offset, readLength);
            }
            else
            {
                //Read from a heap.  They don't automatically checked stream
                //bounds like a node does, make sure you don't read non-accessible memory
                if(static_cast<size_t>(_pos) + length > _heap->size(h_id))
                    length = _heap->size(h_id) - static_cast<size_t>(_pos);

                std::vector<byte> buf(static_cast<size_t>(length));
                readLength = _heap->read(buf, h_id, static_cast<size_t>(_pos));

                unsigned int i;
                for(i = 0; i < buf.size(); i++)
                {
                    buffer[i + offset] = buf[i];
                }
            }

            _pos += readLength;

            return readLength;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reading reading from Stream", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reading reading from Stream");
        }
        finally
        {
            if(pbuffer != nullptr)
                delete[] pbuffer;
        }
    }
    Int64 HnidStreamDevice::Seek(Int64 offset, SeekOrigin seekDirection)
    {
        try
        {
            switch(seekDirection)
            {
            case SeekOrigin::Begin:
                _pos = offset;
                break;
            case SeekOrigin::Current:
                _pos += offset;
                break;
            case SeekOrigin::End:
                _pos = _size + offset;
                break;
            }

            if(_pos < 0)
                _pos = 0;
            else if (_pos > _size)
            {
                _pos = _size;
            }

            return _pos;
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Seek failed.  Shouldn't happen. :/");
        }
    }
}}}}