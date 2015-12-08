#include <iostream>
using namespace std;

const int N = 1e3;
bool Natural[N];
void sieve(int input_data) {	
	for (int i = 2; i*i < input_data; ++i) {
		if (Natural[i] == 0) {
			for (int j = i*i; j < input_data; j += i) {
				Natural[j] = 1;
			}
		}
	}
}

int main() {
	int input_data;
	cin >> input_data;
	sieve(input_data);
	for (int i = 2; i < input_data; ++i) {
		if (Natural[i] == 0) {
			cout << i << ' ';
		}
	}
}