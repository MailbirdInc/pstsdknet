#pragma once

#include "..\..\StdAfx.h"
#include "pst.h"
#include "..\..\ndb\context\DBAccessor.h"
#include "..\..\util\clr_scoped_ptr.h"

using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace System::Reflection;

using namespace pstsdk;
using namespace pstsdk::mcpp::ndb::database;
using namespace pstsdk::definition::ndb::node;
using namespace pstsdk::definition::util::primitives;
using namespace pstsdk::definition::ltp;
using namespace pstsdk::definition::ltp::table;

namespace pstsdk { namespace mcpp { namespace ltp { namespace table 
{ 
	public ref class TableRow : pstsdk::definition::ltp::IPropertyObject
	{
	public:
		TableRow(pstsdk::table table, ulong position, shared_db_ptr pst);

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
		pstsdk::table* GetParentTable();
		shared_db_ptr GetDBHandle();
		ulong GetRowId();

	private:
		clr_scoped_ptr<pstsdk::const_table_row> _row;
		clr_scoped_ptr<pstsdk::table> _parentTable;
		clr_scoped_ptr<shared_db_ptr> _pst;
		ulong _rowId;
	};
}}}}