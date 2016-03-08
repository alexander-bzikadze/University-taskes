all:
	mcs UniqueList.cs ArrayList.cs BasicArrayList.cs ArrayListExceptions.cs -target:library -out:UniqueList.dll
	mcs Main.cs -r:./UniqueList.dll
	mono Main.exe
	mcs UniqueList.Tests.cs ArrayList.Tests.cs BasicArrayList.Tests.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./UniqueList.dll -out:UniqueList.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console UniqueList.Tests.dll