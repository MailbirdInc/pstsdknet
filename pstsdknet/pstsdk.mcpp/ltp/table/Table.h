#pragma once

#include "..\..\Stdafx.h"
#include "pst.h"
#include "..\..\ndb\context\DBAccessor.h"
#include "..\..\util\clr_scoped_ptr.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

using namespace pstsdk::definition::ltp;
using namespace pstsdk::mcpp::ndb::database;

namespace pstsdk { namespace mcpp { namespace ltp { namespace table 
{
    ///<threadsafety instance="true"/>
    ///<summary>
    ///   A collection of TableRows
    ///</summary>
    private ref class Table : IEnumerable<IPropertyObject^>
    {
    public:
        ///<exclude/>
        Table(pstsdk::table Table, shared_db_ptr pst);
        virtual IEnumerator<IPropertyObject^>^ GetEnumerator() sealed = 
            Collections::Generic::IEnumerable<IPropertyObject^>::GetEnumerator;
        virtual Collections::IEnumerator^ GetEnumeratorBase() sealed = 
            Collections::IEnumerable::GetEnumerator;
    private:		
        ref class TableEnumerator : IEnumerator<IPropertyObject^>
        {
        public:
            TableEnumerator(pstsdk::table Table, shared_db_ptr pst);
            property IPropertyObject^ Current
            {
                virtual IPropertyObject^ get() sealed = 
                    Collections::Generic::IEnumerator<IPropertyObject^>::Current::get;
            }
            virtual bool MoveNext() sealed = 
                Collections::Generic::IEnumerator<IPropertyObject^>::MoveNext;
            virtual void Reset() sealed = 
                Collections::Generic::IEnumerator<IPropertyObject^>::Reset;
        private:
            virtual property Object^ CurrentBase
            {
                virtual Object^ get() sealed = 
                    Collections::IEnumerator::Current::get;
            }

            clr_scoped_ptr<pstsdk::table> _table;
            int nodeType;
            int itemCount;
            int m_Current;
            Object^ _lock;
            clr_scoped_ptr<shared_db_ptr> _pst;
        };
        clr_scoped_ptr<shared_db_ptr> _pst;
        clr_scoped_ptr<pstsdk::table> _table;
        Object^ _lock;
    };
}}}}