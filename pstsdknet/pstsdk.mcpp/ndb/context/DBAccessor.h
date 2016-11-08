#pragma once
#include "..\..\StdAfx.h"
#include "pst.h"
#include "..\..\util\clr_scoped_ptr.h"

using namespace pstsdk;
using namespace pstsdk::definition::ltp;
using namespace pstsdk::definition::ltp::nameid;

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace pstsdk { namespace mcpp { namespace ndb { namespace database
{
    public ref class DBContext : pstsdk::definition::ndb::database::IDBAccessor
    {
    public:
        DBContext(String^ fileName);

        virtual IPropertyObject^ GetPropertyObjectByNodeId(UInt32 nodeID);
        virtual IPropertyObject^ DBContext::GetSubObjectByNodeId(IPropertyObject^ parentobject, UInt32 nodeID);
        
        virtual IEnumerable<IPropertyObject^>^ GetSubObjectsByNodeId(IPropertyObject^ parent, UInt32 childNode);
        virtual IEnumerable<IPropertyObject^>^ GetSubObjectsByNidType(IPropertyObject^ parent, NidType nidType);

        virtual IEnumerable<NodeID>^ GetNodeIDsByNodeTypeId(NidType nidType);

        virtual int GetSubObjectCountByNodeId(IPropertyObject^ parent, UInt32 childNode);
        virtual int GetSubObjectCountByNidType(IPropertyObject^ parent, NidType nidType);

        virtual property IEnumerable<NodeInfo>^ Nodes
        { virtual IEnumerable<NodeInfo>^ get(); }

        virtual property IEnumerable<BlockInfo>^ Blocks
        { virtual IEnumerable<BlockInfo>^ get(); }

    internal: 
        pstsdk::shared_db_ptr GetDB();
    private:
        clr_scoped_ptr<shared_db_ptr> _pst;
    };

    private ref class NodeIdCollection : IEnumerable<NodeID>
    {
    public:
        NodeIdCollection(shared_db_ptr dbHandle, NidType nidType);
        virtual IEnumerator<NodeID>^ GetEnumerator() sealed = 
            Collections::Generic::IEnumerable<NodeID>::GetEnumerator;
        virtual Collections::IEnumerator^ GetEnumeratorBase() sealed = 
            Collections::IEnumerable::GetEnumerator;
    private:		
        ref class NodeIdEnumerator : IEnumerator<NodeID>
        {
        public:
            NodeIdEnumerator(shared_db_ptr dbHandle, NidType nidType);
            property NodeID Current
            {
                virtual NodeID get() sealed = 
                    Collections::Generic::IEnumerator<NodeID>::Current::get;
            }
            virtual bool MoveNext() sealed = 
                Collections::Generic::IEnumerator<NodeID>::MoveNext;
            virtual void Reset() sealed = 
                Collections::Generic::IEnumerator<NodeID>::Reset;
        private:
            virtual property Object^ CurrentBase
            {
                virtual Object^ get() sealed = 
                    Collections::IEnumerator::Current::get;
            }
            List<NodeID>^ _nodes;
            int m_Current;
            bool _isConstrained;
            clr_scoped_ptr<shared_db_ptr>  _dbHandle;
            clr_scoped_ptr<boost::filter_iterator<is_nid_type<nid_type_folder>, const_nodeinfo_iterator>*> node_end;
            clr_scoped_ptr<boost::filter_iterator<is_nid_type<nid_type_folder>, const_nodeinfo_iterator>*> node_begin;
            Object^ _lock;
        };

        clr_scoped_ptr<shared_db_ptr> _dbHandle;
        NidType type;
        Object^ _lock;
    };
}}}}