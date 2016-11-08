#include "StdAfx.h"
#include "NodeInfoCollection.h"
#include "pst.h"

#include "..\context\DBAccessor.h"

using namespace pstsdk;
using namespace pstsdk::definition::ltp;
using namespace pstsdk::definition::ltp::nameid;
using namespace pstsdk::definition::util::primitives;

using namespace System;
using namespace System::Threading;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace pstsdk { namespace mcpp { namespace ndb { namespace database
{
    // NodeInfoCollection
    NodeInfoCollection::NodeInfoCollection(shared_db_ptr dbHandle)
        : _dbHandle(new shared_db_ptr(dbHandle)),
          _lock(gcnew Object())
    { }

    IEnumerator<NodeInfo>^ NodeInfoCollection::GetEnumerator()
    {
        Monitor::Enter(_lock);
        try
        {
            return gcnew NodeInfoEnumerator(*_dbHandle);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id from NodeInfoCollection.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id from NodeInfoCollection.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    Collections::IEnumerator^ NodeInfoCollection::GetEnumeratorBase()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerable<NodeInfo>^)this)->GetEnumerator();
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id enumerator from NodeInfoCollection.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id enumerator from NodeInfoCollection.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }

    NodeInfoCollection::NodeInfoEnumerator::NodeInfoEnumerator(shared_db_ptr dbHandle)
        : _dbHandle(new shared_db_ptr(dbHandle)),
          _lock(gcnew Object())
    {
        try
        {
            shared_db_ptr m_db = *_dbHandle;

            this->_nodes = gcnew List<NodeInfo>;

            pstsdk::btree_node<node_id, node_info>::const_iterator begin = m_db->read_nbt_root()->begin();
            pstsdk::btree_node<node_id, node_info>::const_iterator end = m_db->read_nbt_root()->end();

            while(begin != end)
            {
                pstsdk::node_info n = *begin;

                NodeInfo ni;
                ni.NodeId = n.id;
                ni.DataBlockId = n.data_bid;
                ni.SubBlockId = n.sub_bid;
                ni.ParentNodeId = n.parent_id;

                _nodes->Add(ni);
                begin++;
            }
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing NodeInfoEnumerator instance.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing NodeInfoEnumerator instance.");
        }
    }

    void NodeInfoCollection::NodeInfoEnumerator::Reset()
    {
        Monitor::Enter(_lock);
        try
        {
            m_Current = -1;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reseting node id enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error reseting node id enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    bool NodeInfoCollection::NodeInfoEnumerator::MoveNext()
    {
        Monitor::Enter(_lock);
        try
        {
            m_Current++;

            return(m_Current < _nodes->Count);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching next element in node id enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching next element in node id enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    NodeInfo NodeInfoCollection::NodeInfoEnumerator::Current::get()
    {
        Monitor::Enter(_lock);
        try
        {
            if(m_Current == -1)
                throw gcnew InvalidOperationException();

            return _nodes[m_Current]; 
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in node id enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in node id enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    Object^ NodeInfoCollection::NodeInfoEnumerator::CurrentBase::get()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerator<NodeInfo>^)this)->Current; 
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in node id enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in node id enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }


}}}}