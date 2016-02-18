#include <iostream>
using namespace std;

int exp1(int numb, int exp)
{
	int result = 1;
	for (int i = 1; i <= exp; ++i)
	{
		result *= numb;
	}
	return result;
}

int exp2(int numb, int exp)
{
	int result = 1;
	for (int i = exp; i > 0; i >>= 1)
	{
		if (i & 1)
		{
			result *= numb;
		}
		numb *= numb;
	}
	return result;
}

int main()
{
	int numb = 0, exp = 0;
	cout << "Enter the number, then enter its exponent\n";
	cin >> numb >> exp;
	bool way = false;
	cout << "Type 0 for a dump way, type 1 if you want it being done smart\n";
	cin >> way;
	if (way == false)
	{
		cout << exp1(numb, exp);
	}
	else
	{
		cout << exp2(numb, exp);
	}
}