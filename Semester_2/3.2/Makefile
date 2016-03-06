all:
	mcs HashTable.cs List.cs IHash.cs Hash1.cs Hash2.cs BasicArrayList.cs -target:library -out:HashTable.dll
	mcs Main.cs -r:./HashTable.dll
	mono Main.exe
	mcs HashTable.Tests.cs -target:library -r:/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll -r:./HashTable.dll -out:HashTable.Tests.dll
	MONO_PATH=/usr/lib/cli/nunit.framework-2.6.3/nunit.framework.dll  nunit-console HashTable.Tests.dll