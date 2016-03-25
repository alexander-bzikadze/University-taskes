all:
	mcs ./*.cs -target:library -out:Queue.dll
	mcs Main.cs -r:./Queue.dll -target:exe -out:Main.exe
	mono Main.exe
	mcs Tests/*.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./Queue.dll -out:Queue.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console Queue.Tests.dll