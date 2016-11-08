#pragma once
#include "..\..\StdAfx.h"
#include "..\context\DBAccessor.h"
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
	private ref class NodeInfoCollection : IEnumerable<NodeInfo>
	{
	public:
		NodeInfoCollection(shared_db_ptr dbHandle);
		virtual IEnumerator<NodeInfo>^ GetEnumerator() sealed = 
			Collections::Generic::IEnumerable<NodeInfo>::GetEnumerator;
		virtual Collections::IEnumerator^ GetEnumeratorBase() sealed = 
			Collections::IEnumerable::GetEnumerator;
	private:		
		ref class NodeInfoEnumerator : IEnumerator<NodeInfo>
		{
		public:
			NodeInfoEnumerator(shared_db_ptr dbHandle);
			property NodeInfo Current
			{
				virtual NodeInfo get() sealed = 
					Collections::Generic::IEnumerator<NodeInfo>::Current::get;
			}
			virtual bool MoveNext() sealed = 
				Collections::Generic::IEnumerator<NodeInfo>::MoveNext;
			virtual void Reset() sealed = 
				Collections::Generic::IEnumerator<NodeInfo>::Reset;
		private:
			virtual property Object^ CurrentBase
			{
				virtual Object^ get() sealed = 
					Collections::IEnumerator::Current::get;
			}
			List<NodeInfo>^ _nodes;
			int m_Current;
			bool _isConstrained;
			clr_scoped_ptr<shared_db_ptr>  _dbHandle;
			Object^ _lock;
		};
		clr_scoped_ptr<shared_db_ptr> _dbHandle;
		Object^ _lock;
	};
}}}}