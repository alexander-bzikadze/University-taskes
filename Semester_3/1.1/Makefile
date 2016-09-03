all:
	mcs *.cs -out:Main.exe
	mono Main.exe
test: 
	mcs *.cs -target:library -out:BinaryTree.dll
	mcs Tests/*.cs -target:library -r:/Library/Frameworks/Mono.framework//Versions/4.2.4/lib/mono/4.5/nunit.framework.dll -r:./BinaryTree.dll -out:BinaryTree.Tests.dll
	MONO_PATH=/Library/Frameworks/Mono.framework//Versions/4.2.4/lib/mono/4.5/nunit.framework.dll nunit-console BinaryTree.Tests.dll