all:
	mcs ParsingTree.cs ParsingTreeConstructor.cs ParsingTreeConstructor.Exceptions.cs ParsingStack.cs ParsingStack.Exceptions.cs ParsingStackElement.cs Operation.cs Operation.Exceptions.cs Operand.cs -target:library -out:ParsingTree.dll
	mcs Main.cs -r:./ParsingTree.dll
	mono Main.exe
	mcs ParsingTree.Tests.cs ParsingStack.Tests.cs Operation.Tests.cs Operand.Tests.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./ParsingTree.dll -out:ParsingTree.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console ParsingTree.Tests.dll