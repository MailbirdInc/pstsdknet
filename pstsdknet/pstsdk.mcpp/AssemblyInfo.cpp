#include "stdafx.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;

//
// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly:AssemblyTitleAttribute("pstsdk.mcpp")];
[assembly:AssemblyDescriptionAttribute("pstsdk.mcpp")];
[assembly:AssemblyConfigurationAttribute("")];
[assembly:AssemblyCompanyAttribute("pstsdk.net")];
[assembly:AssemblyProductAttribute("pstsdk.mcpp")];
[assembly:AssemblyCopyrightAttribute("Copyright (C) 2010 Troy Howard (thoward37@gmail.com) and Christopher Currens (currens.chris@gmail.com).  Parts copyright R Benjamin Voigt (richardvoigt@gmail.com)")];
[assembly:AssemblyTrademarkAttribute("")];
[assembly:AssemblyCultureAttribute("")];

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the value or you can default the Revision and Build Numbers
// by using the '*' as shown below:

[assembly:AssemblyVersionAttribute("1.0.*")];

[assembly:ComVisible(false)];

[assembly:CLSCompliantAttribute(true)];

[assembly:SecurityPermission(SecurityAction::RequestMinimum, UnmanagedCode = true)];

[assembly:System::Runtime::CompilerServices::InternalsVisibleTo("pstsdk.mcpp.test1")];