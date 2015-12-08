#include <iostream>
using namespace std;
#include <cstring>
#include <stdlib.h>

const char br1 = '{', br2 = '[', br3 = '(' , br4 = '<'; //these will be called "brackets"

const int N = 100;

char toReverse(char bracket) // transforming '{' into '}', '(' into ...
{
	if (bracket == '(') 
	{
		return bracket + 1;
	}
	else
	{
		return bracket + 2;
	}
}

bool check1(char simb) //checking simb to be a bracket
{
	if (simb == br1 or simb == br2 or simb == br3 or simb == br4)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool check2(char simb) //checking simb to be a reversed bracket
{
	if (simb == br1 + 2 or simb == br2 + 2 or simb == br3 + 1 or simb == br4 + 2)
	{
		return true;
	}
	else
	{
		return false;
	}
}

void exit1(char simb) //checking new cycle not to start with a reversed bracket as a normal
{
	if (check2(simb))
		{
			cout << "Unexpected " << simb << " found!";
			exit(EXIT_FAILURE);
		}
}

void exit2(int count) //checking that 
{
	if (count != 0)
		{
			cout << "Wrong number of brackets!";
			exit(EXIT_FAILURE);
		}
}

int rule(char* str, int i, char bracket) //Main check
{
	char bracRvsd = toReverse(bracket);
	int count = 0;
	exit1(str[i]);
	while (str[i] != 0)
	{
		if (check1(str[i]) or check2(str[i]))
		{
			if (str[i] == bracket) //standart ++counter
			{
				++count;
				++i;
				continue;
			}
			if (str[i] == bracRvsd) //standart --counter
			{
				--count;
				++i;
				continue;
			}
			if (count == 0) //a way to start next cycle correctly
			{
				if (check1(str[i]))
				{
					i = rule(str, i, str[i]);
					return i;
				}
				else if (check2(str[i]))
				{
					return i;
				}
			}
			if (check1(str[i])) //starting an inner cycle
			{
				i = rule(str, i, str[i]);
				continue;
			}
			exit1(str[i]);
		}
		else
		{
			++i;
		}
	}
	exit2(count);
	return i;
}

void final(char* str) //checking lenght of the input string to be Even
{
	int count = 0, i = 0;
	char str2[N];
	memset(str2, 0, sizeof(char)*100);
	while (str[i] != 0)
	{
		if (check1(str[i]) or check2(str[i]))
		{
			str2[count] = str[i];
			cout << str[i] << ' ';
			++count;
		}
		++i;
	}
	cout << str2 << '\n';
	i = 0;
	if (count % 2 == 0)  
	{
		rule(str, i, str2[i]);
	}
	else
	{
		cout << "You don't fool me! Length must be even!"; //arb to Queen
		exit(EXIT_FAILURE);
	}
}

int main() 
{
	char str[N];
	cin >> str;
	final(str);
	cout << "Finally...";
	return 0;
}