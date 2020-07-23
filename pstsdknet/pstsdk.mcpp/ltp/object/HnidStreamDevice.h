#pragma once

#include "..\..\StdAfx.h"
#include "pst.h"
#include "..\table\Table.h"
#include "..\table\TableRow.h"
#include "..\propbag\PropertyBag.h"

//using namespace std;
using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace System::Text;

using namespace pstsdk;

using namespace pstsdk::mcpp::ltp::table;
using namespace pstsdk::mcpp::ltp::propbag;

using namespace pstsdk::definition::ndb::database;
using namespace pstsdk::definition::ltp;
using namespace pstsdk::definition::util::primitives;

namespace pstsdk { namespace mcpp { namespace ltp { namespace object
{
    public ref class HnidStreamDevice : pstsdk::definition::ltp::IHnidStreamDevice, System::IO::Stream
    {
    public:
        ///<exclude/>
        HnidStreamDevice(IPropertyObject^ object, PropId propId);
        HnidStreamDevice(TableRow^ row, PropId propId);
        HnidStreamDevice(PropertyBag^ propBag, PropId propId);

        virtual void Flush() override;
        virtual int Read(array<byte>^ buffer, int offset, int count) override;
        virtual Int64 Seek(Int64 offset, SeekOrigin origin) override;
        virtual void SetLength(Int64 value) override;
        virtual void Write(array<byte>^ buffer, int offset, int count) override;
        virtual int ReadByte() override;

        virtual property bool CanRead
        { bool get() override; }
        virtual property bool CanSeek
        { bool get() override; }
        virtual property bool CanWrite
        { bool get() override; }
        virtual property Int64 Length 
        { Int64 get() override; }
        virtual property Int64 Position
        { Int64 get() override; void set(Int64 value) override; }

    private:
        void SetupStream(pstsdk::node n);

        clr_scoped_ptr<shared_db_ptr> _db;
        clr_scoped_ptr<pstsdk::node_impl> _node;
        clr_scoped_ptr<pstsdk::heap> _heap;
        heapnode_id h_id;
        bool isHeap;
        bool isTable;
        Int64 _size;
        Int64 _pos;
    };
}}}}