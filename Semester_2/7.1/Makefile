all:
	mcs *.cs -target:exe -out:Main.exe
	mono Main.exe
test: 
	mcs *.cs -target:library -out:List.dll
	mcs Tests/*.cs -target:library -r:/Library/Frameworks/Mono.framework//Versions/4.2.3/lib/mono/4.5/nunit.framework.dll -r:./List.dll -out:List.Tests.dll
	MONO_PATH=/Library/Frameworks/Mono.framework//Versions/4.2.3/lib/mono/4.5/nunit.framework.dll nunit-console -load=SetTests.SetTest List.Tests.dll