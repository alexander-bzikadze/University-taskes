all:
	mcs EventLoop.cs Coordinates.cs ConsoleTravel.cs Exception/*.cs -target:library -out:ConsoleTravel.dll
	mcs Main.cs -r:./ConsoleTravel.dll
	clear
	mono Main.exe
	clear