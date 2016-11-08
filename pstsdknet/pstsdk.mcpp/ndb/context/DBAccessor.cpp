#include "StdAfx.h"
#include "DBAccessor.h"
#include "pst.h"

#include "..\node\NodeInfoCollection.h"
#include "..\block\BlockInfoCollection.h"

#include "..\..\ltp\propbag\PropertyBag.h"
#include "..\..\ltp\table\TableRow.h"
#include "..\..\ltp\table\Table.h"

using namespace pstsdk;
using namespace pstsdk::definition::ltp;
using namespace pstsdk::definition::ltp::nameid;
using namespace pstsdk::definition::util::primitives;
using namespace pstsdk::mcpp::ltp::propbag;
using namespace pstsdk::mcpp::ltp::table;

using namespace System;
using namespace System::Threading;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;



namespace pstsdk { namespace mcpp { namespace ndb { namespace database
{
    // db context...
    DBContext::DBContext(String^ fileName)
    {
        wchar_t* str = nullptr;

        try
        {
            str = (wchar_t *)Marshal::StringToHGlobalUni(fileName).ToPointer();
            _pst = new shared_db_ptr(open_database(str));
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing Pst instance.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing Pst instance.");
        }
        finally
        {
            if(str != nullptr)
                Marshal::FreeHGlobal(IntPtr(str));
        }
    }

    shared_db_ptr DBContext::GetDB()
    {
        try
        {
            return *_pst;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing Pst instance.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing Pst instance.");
        }
    }

    ///<summary>
    ///Returns a new IPropertyObject using a NodeId from the Root NBT
    ///</summary>
    IPropertyObject^ DBContext::GetPropertyObjectByNodeId(UInt32 nodeID)
    {
        try
        {
            return gcnew PropertyBag((*_pst)->lookup_node(nodeID), *_pst);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from node", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from node");
        }
    }
    ///<summary>
    ///Returns a new IPropertyObject using a NodeId from an SubObject's NBT
    ///</summary>
    IPropertyObject^ DBContext::GetSubObjectByNodeId(IPropertyObject^ parentobject, UInt32 nodeID)
    {
        try
        {
            PropertyBag^ pb = dynamic_cast<PropertyBag^>(parentobject);
            if(parentobject != nullptr)
                return gcnew PropertyBag(pb->GetPropertyBag()->get_node().lookup(nodeID), *_pst);
            else
                throw gcnew pstsdk::definition::exception::PstSdkException("Object mistype while trying to create sub objects!");
        }
        catch(System::Runtime::InteropServices::SEHException^ sehEx) // structured exception handling exception
        {
            throw gcnew pstsdk::definition::exception::PstSdkSEHException("Error creating child object from node", sehEx);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating child object from node");
        }
    }

    IEnumerable<IPropertyObject^>^ DBContext::GetSubObjectsByNidType(IPropertyObject^ parent, NidType nidType)
    {
        try
        {
            PropertyBag^ pb = dynamic_cast<PropertyBag^>(parent);
            if(nullptr != pb)
            {				
                uint childNode = make_nid((uint)nidType, get_nid_index((uint)pb->Node));
                pstsdk::table t = table((*_pst)->lookup_node(childNode));

                return gcnew Table(t, *_pst);
            }
            else
                throw gcnew pstsdk::definition::exception::PstSdkException("Object has no sub table to create sub objects!");

        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode");
        }
    }
    int DBContext::GetSubObjectCountByNidType(IPropertyObject^ parent, NidType nidType)
    {
        try
        {
            PropertyBag^ pb = dynamic_cast<PropertyBag^>(parent);
            if(nullptr != pb)
            {
                uint childNode = make_nid((uint)nidType, get_nid_index((uint)pb->Node));
                
                pstsdk::table t = table((*_pst)->lookup_node(childNode));///pb->Node).lookup(childNode));
                //pstsdk::table t = table(pb->GetPropertyBag()->get_node().lookup(childNode));
                return t.size();			
            }
            else
                throw gcnew pstsdk::definition::exception::PstSdkException("Object has no sub table to create sub objects!");
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode");
        }
    }

    IEnumerable<IPropertyObject^>^ DBContext::GetSubObjectsByNodeId(IPropertyObject^ parent, UInt32 childNode)
    {
        try
        {
            PropertyBag^ pb = dynamic_cast<PropertyBag^>(parent);
            if(nullptr != pb)
            {
                pstsdk::table t = table(pb->GetPropertyBag()->get_node().lookup(childNode));
                return gcnew Table(t, *_pst);
            }
            else
                throw gcnew pstsdk::definition::exception::PstSdkException("Object has no sub table to create sub objects!");

        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode");
        }
    }

    int DBContext::GetSubObjectCountByNodeId(IPropertyObject^ parent, UInt32 childNode)
    {
        try
        {
            PropertyBag^ pb = dynamic_cast<PropertyBag^>(parent);
            if(nullptr != pb)
            {
                //pstsdk::table t = table(_pst->GetDB()->lookup_node(pb->Node).lookup(childNode));
                pstsdk::table t = table(pb->GetPropertyBag()->get_node().lookup(childNode));
                return t.size();			
            }
            else
                throw gcnew pstsdk::definition::exception::PstSdkException("Object has no sub table to create sub objects!");

        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode");
        }
    }
    
    IEnumerable<NodeID>^ DBContext::GetNodeIDsByNodeTypeId(NidType nidType)
    {
        try
        {
            return gcnew NodeIdCollection(*_pst, nidType);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating object from subnode");
        }
    }

    IEnumerable<NodeInfo>^ DBContext::Nodes::get()
    {
        try
        {
            return gcnew NodeInfoCollection(*_pst);
        }
        catch(System::Exception^ ex)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating node list", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating node list");
        }
    }

    IEnumerable<BlockInfo>^ DBContext::Blocks::get()
    {
        try
        {
            return gcnew BlockInfoCollection(*_pst);
        }
        
        catch(System::Exception^ ex)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating block list", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error creating block list");
        }
    }

    // NodeIdCollection
    NodeIdCollection::NodeIdCollection(shared_db_ptr dbHandle, NidType nidType)
        : _dbHandle(new shared_db_ptr(dbHandle)),
          _lock(gcnew Object())
    {	
        type = nidType;
    }

    IEnumerator<NodeID>^ NodeIdCollection::GetEnumerator()
    {
        Monitor::Enter(_lock);
        try
        {
            return gcnew NodeIdEnumerator(*_dbHandle, type);
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id from NodeIdCollection.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id from NodeIdCollection.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    Collections::IEnumerator^ NodeIdCollection::GetEnumeratorBase()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerable<NodeID>^)this)->GetEnumerator();
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id enumerator from NodeIdCollection.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error fetching node id enumerator from NodeIdCollection.");
        }
        finally
        {
            Monitor::Exit(_lock);
        }
    }
    NodeIdCollection::NodeIdEnumerator::NodeIdEnumerator(shared_db_ptr dbHandle, NidType nidType)
        : _dbHandle(new shared_db_ptr(dbHandle)),
          _lock(gcnew Object())
    {
        try
        {		
            shared_db_ptr m_db = *_dbHandle;
            //is_nodeid_type foo = new is_nodeid_type();
            //foo.Type = nidType;

            this->_nodes = gcnew List<NodeID>;

            if((uint)nidType == (uint)nid_type_folder)
            {
                boost::filter_iterator<				
                    is_nid_type<nid_type_folder>, 
                    const_nodeinfo_iterator>

                    node_begin = 
                    boost::make_filter_iterator<is_nid_type<nid_type_folder> >(
                            m_db->read_nbt_root()->begin(), 
                            m_db->read_nbt_root()->end()
                            );

                boost::filter_iterator< 
                    is_nid_type<nid_type_folder>, 
                    const_nodeinfo_iterator>

                    node_end = 
                    boost::make_filter_iterator<is_nid_type<nid_type_folder> >(
                            m_db->read_nbt_root()->end(), 
                            m_db->read_nbt_root()->end()
                            );
                                        
                
                while(node_begin != node_end)
                {				
                    pstsdk::node_info n = *node_begin;
                    _nodes->Add(n.id);
                    node_begin++;
                }
            }
            else if((uint)nidType == (uint)nid_type_message)
            {
                boost::filter_iterator<				
                    is_nid_type<nid_type_message>, 
                    const_nodeinfo_iterator>

                    node_begin = 
                    boost::make_filter_iterator<is_nid_type<nid_type_message> >(
                            m_db->read_nbt_root()->begin(), 
                            m_db->read_nbt_root()->end()
                            );

                boost::filter_iterator< 
                    is_nid_type<nid_type_message>, 
                    const_nodeinfo_iterator>

                    node_end = 
                    boost::make_filter_iterator<is_nid_type<nid_type_message> >(
                            m_db->read_nbt_root()->end(), 
                            m_db->read_nbt_root()->end()
                            );
                                        
                
                while(node_begin != node_end)
                {				
                    pstsdk::node_info n = *node_begin;
                    _nodes->Add(n.id);
                    node_begin++;
                }
            }
            else 
            {
                throw gcnew NotImplementedException();
            }
            
            m_Current = -1;
        }
        catch(System::Exception^ ex) // .NET Managed exception 
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing NodeIdEnumerator instance.", ex);
        }
        catch(...)
        {
            throw gcnew pstsdk::definition::exception::PstSdkException("Error constructing NodeIdEnumerator instance.");
        }
    }

    void NodeIdCollection::NodeIdEnumerator::Reset()
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
    bool NodeIdCollection::NodeIdEnumerator::MoveNext()
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
    NodeID NodeIdCollection::NodeIdEnumerator::Current::get()
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
    Object^ NodeIdCollection::NodeIdEnumerator::CurrentBase::get()
    {
        Monitor::Enter(_lock);
        try
        {
            return ((IEnumerator<NodeID>^)this)->Current; 
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