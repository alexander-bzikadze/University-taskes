#include <iostream>
using namespace std;
const int N = 1000;

int a[N], an;

void solve(int n, int K) {
	if (!n) { // if (n == 0)
		for(int i = 0; i < an; ++i)
			cout << a[i] << " \n"[i == an - 1];
		return;
	}
	for(int k = 0; k < min(K, n); k++) {
		a[an++] = k + 1;
		solve(n - k - 1, k + 1);
		an--;
	}
}
 
int main() {
	int n;
	cin >> n;
	solve(n, n);
	//cout << (int) true << endl;
	// int i = 10;
	// while(--i)
	// 	cout << i << endl;
}