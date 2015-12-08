#include "reader.h"

// template <class T>
// void Reader<T>::read()
// {
//     calcOnList = false;
//     std::cin >> calcOnList;
//     input[maxSize] = {};
//     size = 0;
//     while (size == 0)
//     {
//         std::cin.getline(input, maxSize);
//         size = 0;
//         while (size < maxSize && input[size] != 0 && input[size] != 0)
//         {
//             ++size;
//         }
//     }
// }

// template <class T>
// char * Reader<T>::inputed()
// {
//     return input;
// }

// template <class T>
// void Reader<T>::calculate()
// {
//     int number = 0;
//     for (int i = 0; i < size; ++i)
//     {
//         if ('0' <= input[i] <= '9')
//         {
//             number *= 10;
//             number += input[i];
//         }
//         else if (input[i] == ' ')
//         {
//             calc.push(number);
//             number = 0;
//         }
//         else switch(input[i])
//         {
//             case '+':
//             {
//                 calc.add();
//                 break;
//             }
//             case '-':
//             {
//                 calc.subtract();
//                 break;
//             }
//             case '*':
//             {
//                 calc.multiply();
//                 break;
//             }
//             case ':':
//             {
//                 calc.divide();
//                 break;
//             }
//             default:
//             {
//                 break;
//             }
//         }
//     }
// }