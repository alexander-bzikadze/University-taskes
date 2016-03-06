all:
	mcs Calculator.cs IStack.cs ArrayStack.cs List.cs BasicArrayList.cs ReferenceStack.cs -target:library -out:Calculator.dll
	mcs Main.cs -r:./Calculator.dll
	mono Main.exe