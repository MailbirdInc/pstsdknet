#pragma once

#include "../../StdAfx.h"
#include "pst.h"
#include "../../ndb/context/DBAccessor.h"
#include "../../util/clr_scoped_ptr.h"

using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;

using namespace pstsdk;
using namespace pstsdk::mcpp::ndb::database;

using namespace pstsdk::definition::ltp;
using namespace pstsdk::definition::ltp::propbag;
using namespace pstsdk::definition::ltp::table;
using namespace pstsdk::definition::ndb::node;
using namespace pstsdk::definition::util::primitives;

namespace pstsdk { namespace mcpp { namespace ltp { namespace propbag
{
    public ref class PropertyBag : pstsdk::definition::ltp::IPropertyObject
    {
    private:
        clr_scoped_ptr<pstsdk::property_bag> _propBag;
        clr_scoped_ptr<shared_db_ptr> _pst;
    public:
        PropertyBag(pstsdk::node node, shared_db_ptr pst);

        //IPropertyObject methods
        virtual property IEnumerable<PropId>^ Properties
        { IEnumerable<PropId>^ get(); }
        virtual property NodeID Node
        { NodeID get(); }

        virtual PropertyType GetPropertyType(PropId id);
        virtual bool PropertyExists(PropId id);
        virtual unsigned int PropertySize(PropId id);
        virtual array<Byte>^ ReadProperty(PropId id);
        virtual Stream^ OpenPropertyStream(PropId id);

    internal:
        pstsdk::property_bag* GetPropertyBag();
        shared_db_ptr GetDBHandle();
    };
}}}}
