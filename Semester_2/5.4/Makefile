all:
	mcs EventLoop.cs ConsoleTravel.cs Exception/*.cs -target:library -out:ConsoleTravel.dll
	mcs Main.cs -r:./ConsoleTravel.dll
	mono Main.exe