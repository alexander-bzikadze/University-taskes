#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

const int N = 1e2;

bool Array[N];

int main() {
	srand(time(0));
	for (int i = 0; i < rand() % N; ++i) {
		Array[rand() % N] = 1;
	}
	int result = 0;
	for (int i = 0; i < N; ++i) {
		cout << Array[i] << ' ';
		if (Array[i] != 0) {
			++result;
		}
	}
	cout << '\n' << result;
}