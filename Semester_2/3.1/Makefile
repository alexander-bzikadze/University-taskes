all:
	mcs ReferenceStack.cs ReferenceStackElement.cs ReferenceStackExeptions.cs -target:library -out:ReferenceStack.dll
	mcs Main.cs -r:./ReferenceStack.dll
	mono Main.exe
	mcs ReferenceStack.Tests.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./ReferenceStack.dll -out:ReferenceStackTests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console ReferenceStackTests.dll
