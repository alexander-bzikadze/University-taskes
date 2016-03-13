all:
	mcs Filter.cs -target:library -out:Filter.dll
	mcs Main.cs -r:./Filter.dll
	mono Main.exe
	mcs Filter.Tests.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./Filter.dll -out:Filter.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console Filter.Tests.dll