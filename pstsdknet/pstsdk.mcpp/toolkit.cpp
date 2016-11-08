#include "StdAfx.h"
#include "toolkit.h"
#include "pst.h"

namespace pstsdk { namespace mcpp
{
	template<class T>
	DisposableNativeWrapper<T>::DisposableNativeWrapper(T* Class)
	{
		Handle = (T*)malloc(sizeof(T));
		memcpy((void*)Handle, (void*)Class, sizeof(T));
	}
	template<class T>
	DisposableNativeWrapper<T>::~DisposableNativeWrapper()
	{
		free(Handle);
	}

	//Let's define our templates for the stupid VC++ Compiler!
	//export keyword is only reserved, not supported yet. >:O
	template DisposableNativeWrapper<pstsdk::recipient>;
}};