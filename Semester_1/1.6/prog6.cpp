#include <iostream>
using namespace std;
#include <cstring>

int main() 
{
	char S[1000], S1[5];
	cin >> S1 >> S;
	int i = 0, j, result = 0;
	while (S[i] != 0) {
		j = 0;
		while (S1[j] == S[j++ + i]);
		if (j == strlen(S1)+1) {
			++result;
		}
		++i;
	}
	cout << result;
}