#include <iostream> 
#include <cmath>

using namespace std;

const int maxSize = 32;

void seeOut(short * array, int size)
{
    for ( int i = size - 1 ; i >= 0; --i)
    {
        cout << array[i] << ' ';
    }
    cout << endl;
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

int makeItDecimal(short * binary, int size)
{
    int decimal = 0;
    int x = 1;
    for (int i = 0; i < size; ++i)
        {
            if (binary[i])
            {
                decimal += x;
            }
            x *= 2;
        }
    return decimal;
}

int binaryAddition(short * sumBin, short * firstBin, short * secondBin, int firstSize, int secondSize, int difference)
{
    for (int i = 0; i < firstSize; ++i)
    {
        sumBin[i] = firstBin[i];
    }
    for ( int i = difference; i < maxSize; ++i)
    {
        sumBin[i] += secondBin[i];
    }
    int j = -1;
    while (++j < max(firstSize, secondSize - difference) + 1)
        while (sumBin[j] > 1)
        {
            sumBin[j] &= 1;
            sumBin[++j] += 1;
        }
    int size = maxSize;
    while (!sumBin[size])
        {
            --size;
        }
    return size;
}

int countUnits(short * binary, int size)
{
    int counter = 0;
    for (int i = size - 1; i >= 0; --i)
    {
        if (binary[i])
        {
            ++counter;
        }
    }
    return counter;
}

int binaryMultiplication(short * multBin, short * firstBin, short * secondBin, int firstSize, int secondSize)
{
        int size = 0;
        if (countUnits(firstBin, firstSize) < countUnits(secondBin, secondSize))
        {
            size = secondSize;
            for (int i = 0; i < firstSize; ++i)
            {
                ++size;
                if (firstBin[i])
                {
                  binaryAddition(multBin, multBin, secondBin, size, secondSize, i);
                }
            }
        }
        else
        {
            size = firstSize;
            for (int i = 0; i < secondSize; ++i)
            {
                ++size;
                if (secondBin[i])
                {
                    binaryAddition(multBin, multBin, firstBin, size, firstSize, i);
                }
            }
        }
        size = maxSize;
        while (!multBin[size])
        {
            --size;
        }
        return size + 1;
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
    return maxSize;
}

int main()
{
    short firstBin[maxSize] = {};
    short secondBin[maxSize] = {};
    int firstDec = 0;
    int secondDec = 0;
    cin >> firstDec >> secondDec;
    int firstSize = makeItBinary(firstBin, abs(firstDec));
    int secondSize = makeItBinary(secondBin, abs(secondDec));
    firstSize =  makeItNegative(firstBin, firstDec, firstSize);
    secondSize = makeItNegative(secondBin, secondDec, secondSize);
    seeOut(firstBin, firstSize);
    seeOut(secondBin, secondSize);
    short sumBin[maxSize + 1] = {};
    short multBin[maxSize * 2] = {};
    int size = binaryAddition(sumBin, firstBin, secondBin, firstSize, secondSize, 0);
    seeOut(sumBin, size);
    cout << makeItDecimal(sumBin, size) << endl;
    size = binaryMultiplication(multBin, firstBin, secondBin, firstSize, secondSize);
    seeOut(multBin, size);
    cout << makeItDecimal(multBin, size);
}
