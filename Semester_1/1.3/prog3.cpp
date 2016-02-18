#include <iostream>
using namespace std;

const int N=1e3; //assuming N>=m+n

int Alice[N]; //Let's get Alice "Trough the Looking-Glass"

void the_Looking_Glass(int i1, int i2){
	int tmp;
	for (int i=1; i<(i2-i1)/2+1; ++i){
		tmp=Alice[i+i1-1];
		Alice[i+i1-1]=Alice[i2-i];
		Alice[i2-i]=tmp;
	}
	return;
}
int main(){
	int m ,n;
	cin >>m >>n;
	for (int i=0; i<m+n; ++i){
		Alice[i]=i;
		cout <<Alice[i] << ' ';
	}
	cout <<'\n';
	the_Looking_Glass(0,m);
	the_Looking_Glass(m,m+n);
	the_Looking_Glass(0,m+n);
	for (int i=0; i<m+n; ++i){
		cout <<Alice[i] << ' ';
	}
}