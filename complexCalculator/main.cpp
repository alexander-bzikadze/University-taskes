#include "Calculator.h"
#include "Complex.h"

using namespace std;

int main()
{
    ArrayStack<Complex<double>> * stack = new ArrayStack<Complex<double>>();
    Calculator<Complex<double>> calc(*stack);
    calc.push(Complex<double>(1));
    calc.push(Complex<double>(1, 1));
    calc.divide();
    cout << calc.result().realPart() << ' ' << calc.result().imaginaryPart() << 'i' << endl;
    delete stack;
    return 0;
}