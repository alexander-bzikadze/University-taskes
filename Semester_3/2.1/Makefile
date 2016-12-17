all:
	mcs Main.cs Os.cs Virus.cs Net.cs Computer.cs Logic.cs Reader.cs Viewer.cs IReader.cs IViewer.cs NullOs.cs ReadResult.cs -out:Main.exe
	mono Main.exe >output.txt
test: 
	mcs Main.cs Os.cs Virus.cs Net.cs Computer.cs Logic.cs Reader.cs Viewer.cs IReader.cs IViewer.cs NullOs.cs ReadResult.cs -target:library -out:Net.dll
	mcs Tests/*.cs -target:library -r:/Library/Frameworks/Mono.framework//Versions/4.2.4/lib/mono/4.5/nunit.framework.dll -r:./Net.dll -out:Net.Tests.dll
	MONO_PATH=/Library/Frameworks/Mono.framework//Versions/4.2.4/lib/mono/4.5/nunit.framework.dll nunit-console Net.Tests.dll