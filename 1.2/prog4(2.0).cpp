#include <iostream>
using namespace std;

int replace_char(int input){
	if (input < 0){
		return input*=(-1);
	}
	return input;
}
int main(){
	int number, divider, result, positiveness = 1;
	result = 0;
	cin >>number >>divider;
	if (number*divider < 0) {positiveness*=(-1);}
	number = replace_char(number);
	divider = replace_char(divider);
	if (number < divider){
		cout <<result;
		return 0;
	}
	while (number >= divider){
		number -= divider;
		++result;
	}
	cout <<result*positiveness;
	return 0;
}