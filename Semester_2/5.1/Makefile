all:
	mcs Map.cs -target:library -out:Map.dll
	mcs Main.cs -r:./Map.dll
	mono Main.exe
	mcs Map.Tests.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./Map.dll -out:Map.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console Map.Tests.dll