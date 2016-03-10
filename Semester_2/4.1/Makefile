all:
	mcs Exceptions/*.cs ParsingStack/*.cs ParsingTree/*.cs ParsingTreeVertex/*.cs -target:library -out:ParsingTree.dll
	mcs Main.cs -r:./ParsingTree.dll
	mono Main.exe
	mcs Tests/*.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./ParsingTree.dll -out:ParsingTree.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console ParsingTree.Tests.dll