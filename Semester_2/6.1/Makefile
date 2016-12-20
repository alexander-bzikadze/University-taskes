all:
	mcs -pkg:dotnet ./main/Main.cs -recurse:./src/*.cs -target:exe -out:./bin/Calculator.exe
run: all
	mono ./bin/Calculator.exe