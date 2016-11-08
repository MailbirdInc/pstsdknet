#include "StdAfx.h"
#include "pst.h"
#include "Table.h"
#include "TableRow.h"
#include "..\propbag\PropertyBag.h"

using namespace System;
using namespace System::Threading;
using namespace System::Collections::Generic;

using namespace pstsdk;
using namespace pstsdk::definition::pst::message;
using namespace pstsdk::mcpp::ltp::propbag;
using namespace pstsdk::mcpp::ndb::database;

namespace pstsdk { namespace mcpp { namespace ltp { namespace table 
{
    Table::Table(pstsdk::table Table, shared_db_ptr pst)
        : _lock(gcnew Object()),
          _pst(new shared_db_ptr(pst)),
          _table(new pstsdk::table(Table))
    {	}

    IEnumerator<IPropertyObject^>^ Table::GetEnumerator()
    {
        Monitor::Enter(_lock);
        try
        {
            return gcnew TableEnumerator(*_table, *_pst);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching property object enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching property object enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }

    Collections::IEnumerator^ Table::GetEnumeratorBase()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerable<IPropertyObject^>^)this)->GetEnumerator();
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching property object enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching property object enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }

    Table::TableEnumerator::TableEnumerator(pstsdk::table Table, shared_db_ptr pst)
        : _table(new pstsdk::table(Table)),
          _pst(new shared_db_ptr(pst)),
          _lock(gcnew Object())
    {
        try
        {
            itemCount = _table->size();
            nodeType = _table->get_node().get_id() & 0x1FL;

            m_Current = -1;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing AttachmentEnumerator instance.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing AttachmentEnumerator instance.");
        }
    }

    void Table::TableEnumerator::Reset()
    {
        Monitor::Enter(_lock);
        try
        {
            m_Current = -1;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error resetting table enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error resetting table enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    bool Table::TableEnumerator::MoveNext()
    {
        Monitor::Enter(_lock);
        try
        {
            m_Current++;

            return(m_Current < itemCount);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching next element in table enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching next element in table enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    IPropertyObject^ Table::TableEnumerator::Current::get()
    {
        Monitor::Enter(_lock);
        try
        {
            if(m_Current == -1)
                throw gcnew InvalidOperationException();

            switch(nodeType)
            {
            case nid_type_recipient_table:
                return gcnew TableRow(*_table, m_Current, *_pst);
            case nid_type_attachment_table:
                return gcnew TableRow(*_table, m_Current, *_pst);
            default:
                return gcnew PropertyBag((*_pst)->lookup_node((*_table)[m_Current].get_row_id()), *_pst);
            }

        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in table enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in table enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    Object^ Table::TableEnumerator::CurrentBase::get()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerator<IPropertyObject^>^)this)->Current;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in table enumerator.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching current element in table enumerator.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
}}}};