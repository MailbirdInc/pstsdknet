// pstsdk.net.primitives Namespace
// ------------------------------------------------------------------
// All code files in this folder subject to following copyright details
// unless otherwise specified.
// 
// Copyright (C) 2010 Troy Howard (thoward37@gmail.com) and Christopher Currens
// (currens.chris@gmail.com)
//
// All rights reserved.
// 
// This code module is part of pstsdk.net, a .NET port of the PST File Format SDK.
// ------------------------------------------------------------------
//
// This code is licensed under the Apache Public License. 
// See the file LICENSE.TXT for license details.
// More info on: http://pstsdknet.codeplex.com
//
// ------------------------------------------------------------------
//
// Primitive structures defined by MS-PST and MAPI
//
// This is a port of the file primitives.h in the PST File Format SDK project, 
// written by Terry Mahaffey. 
// 
// The original file is located at: 
// https://fairport.svn.codeplex.com/svn/fairport/trunk/pstsdk/util/primitives.h
//
// ------------------------------------------------------------------

// While porting, I'll be working from the assertions in primitives.h, which 
// suggest that byte is 8bit, ushort is 16bit, uint is 32bit, and ulonglong is 64bit
// which seems to be the LLP64 standard (int/long =32bit, longlong and pointer are 64bit).
