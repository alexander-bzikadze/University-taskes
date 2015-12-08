#include <iostream>
#include <cmath>
#include <clocale>

using namespace std;

/* Tests:
1) -3 588 => 
-3 - 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 
588 - 1 0 0 1 0 0 1 1 0 0 
585 - 1 0 0 1 0 0 1 0 0 1 
2) 3 -588 =>
3 - 1 1 
-588 - 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 1 0 1 1 0 1 0 0 
-585 - 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 1 0 1 1 0 1 1 1 
3) 3 588 =>
3 - 1 1 
588 - 1 0 0 1 0 0 1 1 0 0 
591 - 1 0 0 1 0 0 1 1 1 1 
4)-3 -588
-3 - 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 
-588 - 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 1 0 1 1 0 1 0 0 
-591 - 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 1 0 1 1 0 0 0 1 
*/

int const maxSize = 32;

int returnSize(short * binary)
{
    int size = maxSize - 1;
    while (!binary[size])
        {
            --size;
        }
    // cout << '!' << size << '!' <<endl;
    return size + 1;
}

int makeItBinary(short * binary, int decimal)
{
    int size = 0;
    while (decimal > 0)
    {
        binary[size] = decimal & 1;
        decimal >>= 1;
        ++size;
    }
    return size;
}

long makeItDecimal(short * binary)
{
    long decimal = 0;
    int x = 1;
    for (int i = 0; i < returnSize(binary); ++i)
        {
            if (binary[i])
            {
                decimal += x;
            }
            x *= 2;
        }
    return decimal;
}

void seeOut(short * array, int size)
{
    if (!size)
    {
        ++size;
    }
    cout << makeItDecimal(array) << ": ";
    for ( int i = size - 1 ; i >= 0; --i)
    {
        cout << array[i] << ' ';
    }
    cout << endl;
} 

int makeItNegative(short * binary, int decimal, int size)
{
    if (decimal >= 0)
    {
        return size;
    }
    for (int i = 0; i < maxSize; ++i)
    {
        binary[i] += 1;
        binary[i] &= 1;
    }
    int j = 0;
    binary[j] += 1;
    while ((binary[j] > 1) && (j < maxSize))
    {
        binary[j] &= 1;
        binary[++j] += 1;
    }
    return returnSize(binary);
}

int binaryAddition(short * sumBin, short * firstBin, int firstSize, short * secondBin, int secondSize)
{
    for (int i = 0; i < firstSize; ++i)
    {
        sumBin[i] = firstBin[i];
    }
    for ( int i = 0; i < max(firstSize, secondSize); ++i)
    {
        sumBin[i] += secondBin[i];
    }
    int j = -1;
    while (++j < max(firstSize, secondSize) + 1)
        while (sumBin[j] > 1)
        {
            sumBin[j] &= 1;
            sumBin[++j] += 1;
        }
    return returnSize(sumBin);
}

void seeIn(short * firstBin, short * secondBin, int & firstDec, int & secondDec, int & firstSize, int & secondSize)
{
    cin >> firstDec >> secondDec;
    firstSize = makeItBinary(firstBin, abs(firstDec));
    secondSize = makeItBinary(secondBin, abs(secondDec));
    firstSize = makeItNegative(firstBin, firstDec, firstSize);
    secondSize = makeItNegative(secondBin, secondDec, secondSize);
    seeOut(firstBin, firstSize);
    seeOut(secondBin, secondSize);
}

int main()
{
    setlocale(LC_ALL, "Russian");
    cout << "Введите 2 числа, не превосходящих значений integer и в сумму не дающих число, превосходящее значения integer" << endl;
    cout << "Вам выведут двоичное представление введенных вами чисел, их сумму и двоичное представление суммы (сумма посчитана в двоичном представлении" << endl;
    int firstDec = 0;
    int secondDec = 0;
    short firstBin[maxSize] = {};
    short secondBin[maxSize] = {};
    int firstSize = 0;
    int secondSize = 0;
    seeIn(firstBin, secondBin, firstDec, secondDec, firstSize, secondSize);
    short sumBin[maxSize + 1] = {};
    int sumSize = binaryAddition(sumBin, firstBin, firstSize, secondBin, secondSize);
    seeOut(sumBin, sumSize);
    return 0;
}