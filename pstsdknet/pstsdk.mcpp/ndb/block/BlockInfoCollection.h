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
	private ref class BlockInfoCollection : IEnumerable<BlockInfo>
	{
	public:
		BlockInfoCollection(shared_db_ptr dbHandle);
		virtual IEnumerator<BlockInfo>^ GetEnumerator() sealed = 
			Collections::Generic::IEnumerable<BlockInfo>::GetEnumerator;
		virtual Collections::IEnumerator^ GetEnumeratorBase() sealed = 
			Collections::IEnumerable::GetEnumerator;
	private:		
		ref class BlockInfoEnumerator : IEnumerator<BlockInfo>
		{
		public:
			BlockInfoEnumerator(shared_db_ptr dbHandle);
			property BlockInfo Current
			{
				virtual BlockInfo get() sealed = 
					Collections::Generic::IEnumerator<BlockInfo>::Current::get;
			}
			virtual bool MoveNext() sealed = 
				Collections::Generic::IEnumerator<BlockInfo>::MoveNext;
			virtual void Reset() sealed = 
				Collections::Generic::IEnumerator<BlockInfo>::Reset;
		private:
			virtual property Object^ CurrentBase
			{
				virtual Object^ get() sealed = 
					Collections::IEnumerator::Current::get;
			}
			List<BlockInfo>^ _nodes;
			int m_Current;
			bool _isConstrained;
			clr_scoped_ptr<shared_db_ptr>  _dbHandle;
			Object^ _lock;
		};
		clr_scoped_ptr<shared_db_ptr> _dbHandle;
		Object^ _lock;
	};
}}}}