#pragma once
#include "StdAfx.h"

namespace pstsdk { namespace mcpp
{
	template <class T>
	public class DisposableNativeWrapper
	{
	public:
		T* Handle;
		DisposableNativeWrapper<T>(T* Class);
		~DisposableNativeWrapper<T>();
	};
}}