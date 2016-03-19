
all:
	mcs Fold.cs -target:library -out:Fold.dll
	mcs Main.cs -r:./Fold.dll
	mono Main.exe
	mcs Fold.Tests.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./Fold.dll -out:Fold.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console Fold.Tests.dll