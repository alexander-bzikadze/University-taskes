#include "hash.h"

HashTable::HashTable()
{
    std::fill(list, list + maxSize, List());
}

HashTable::~HashTable()
{
    // list[maxSize] = {};
}

void HashTable::mainProcess()
{
    input();
    print();
}

void HashTable::input()
{
    ifstream file("main.in");
    if (!file.is_open())
    {
        cout << "File!!!" << endl;
    }
    string word = "";
    while (file >> word)
    {
        int i = 0;
        while (i < word.size())
        {
            // if (!isFromAlphabet(word[i]))
            // {
            //     word[i] = ' ';
            //     int j = i + 1;
            //     --i;
            //     while (j < word.size())
            //     {
            //         word[j - 1] = word[j];
            //         ++j;
            //     }
            //     word.pop_back();
            // }
            // else if (isFromHighAlphabet(word[i]))
            // {
            //     word[i] += 'a' - 'A';
            // }
            ++i;
        }
        list[hashFunction(word)].add(word);
    }
}

int HashTable::hashFunction(string const &word)
{
    int result = 0;
    int const alphabetSize = 255;
    if (word.size() > 1)
    {
        for (int i = 0; i < word.size(); ++i)
        {
            result += word[i];
            result %= alphabetSize;
        }
        result += (word[0]) * alphabetSize;
    }
    else
    {
        result += alphabetSize * alphabetSize + word[0];
    }
    return result;
}

void HashTable::print()
{
    for (int i = 0; i < maxSize; ++i)
    {
        if (list[i].doExist())
        {
            list[i].print();
        }
    }
}

// bool HashTable::isFromAlphabet(char i)
// {
//     if (isFromHighAlphabet(i) || i <=122 && i >= 97)
//     {
//         return true;
//     }
//     return false;
// }

// bool HashTable::isFromHighAlphabet(char i)
// {
//     if (i <=90 && i >= 65)
//     {
//         return true;
//     }
//     return false;
// }

// int HashTable::hashFunction(string const &word) //for English
// {
//     int result = 0;
//     int const alphabetSize = 26;
//     if (word.size() > 1)
//     {
//         for (int i = 0; i < word.size(); ++i)
//         {
//             result += word[i] - 'a';
//             result %= alphabetSize;
//         }
//         result += (word[0] - 'a') * alphabetSize;
//     }
//     else
//     {
//         result += alphabetSize * alphabetSize + word[0] - 'a';
//     }
//     return result;
// }