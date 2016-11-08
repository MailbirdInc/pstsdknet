#include "StdAfx.h"
#include "BlockInfoCollection.h"
#include "pst.h"

#include "..\context\DBAccessor.h"
#include "..\..\util\clr_scoped_ptr.h"

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
    // BlockInfoCollection
    BlockInfoCollection::BlockInfoCollection(shared_db_ptr dbHandle)
        : _dbHandle(new shared_db_ptr(dbHandle)),
          _lock(gcnew Object())
    { }

    IEnumerator<BlockInfo>^ BlockInfoCollection::GetEnumerator()
    {
        Monitor::Enter(_lock);
        try
        {
            return gcnew BlockInfoEnumerator(*_dbHandle);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id from BlockInfoCollection.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id from BlockInfoCollection.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    Collections::IEnumerator^ BlockInfoCollection::GetEnumeratorBase()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerable<BlockInfo>^)this)->GetEnumerator();
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id enumerator from BlockInfoCollection.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id enumerator from BlockInfoCollection.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }

    BlockInfoCollection::BlockInfoEnumerator::BlockInfoEnumerator(shared_db_ptr dbHandle)
        : _dbHandle(new shared_db_ptr(dbHandle)),
          _lock(gcnew Object())
    {
        try
        {
            shared_db_ptr m_db = *_dbHandle;

            this->_nodes = gcnew List<BlockInfo>;

            pstsdk::btree_node<block_id, block_info>::const_iterator begin = m_db->read_bbt_root()->begin();
            pstsdk::btree_node<block_id, block_info>::const_iterator end = m_db->read_bbt_root()->end();

            while(begin != end)
            {
                pstsdk::block_info b = *begin;

                BlockInfo bi;

                bi.BlockId = b.id;
                bi.Address = b.address;
                bi.Size = b.size;
                bi.RefCount = b.ref_count;

                _nodes->Add(bi);
                begin++;
            }
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing BlockInfoEnumerator instance.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing BlockInfoEnumerator instance.");
        }
    }

    void BlockInfoCollection::BlockInfoEnumerator::Reset()
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
    bool BlockInfoCollection::BlockInfoEnumerator::MoveNext()
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
    BlockInfo BlockInfoCollection::BlockInfoEnumerator::Current::get()
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
    Object^ BlockInfoCollection::BlockInfoEnumerator::CurrentBase::get()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerator<BlockInfo>^)this)->Current; 
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