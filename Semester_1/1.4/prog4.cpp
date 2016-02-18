#include <iostream>
using namespace std;


int main(){
	const int N = 27, M = 10;
	int sum[N+1]; //summary of the one half of a lucky ticket
	for (int i = 0; i <= N; ++i){
		sum[i] = 0;
	}
	for (int i = 0; i < M; ++i){
		for (int j = 0; j < M; ++j){
			for (int k = 0; k < M; ++k){
				++sum[k+i+j];
			}
		}
	}
	int result = 0;
	for (int i = 0; i <= N; ++i){
		cout <<sum[i] <<' ';
		result+=sum[i]*sum[i];
	}
	cout <<result;
}
