#pragma once
#include <iostream>

template <typename T>

class Complex
{
public:
    Complex() : real(), imaginary() {};
    Complex(T const &real) : real(real), imaginary() {};
    Complex(T const &real, T const &imaginary) : real(real), imaginary(imaginary) {};

    Complex operator + (Complex const &second)
    {
        return Complex(real + second.real, imaginary + second.imaginary);
    }
    Complex operator + (T const &second)
    {
        return Complex(real + second.real, imaginary);
    }

    Complex operator - (Complex const &second)
    {
        return Complex(real - second.real, imaginary - second.imaginary);
    }
    Complex operator - (T const &second)
    {
        return Complex(real - second.real, imaginary);
    }

    Complex operator * (Complex const &second)
    {
        return Complex(real * second.real - imaginary * second.imaginary, 
            imaginary * second.real + real * second.imaginary);
    }
    Complex operator * (T const &second)
    {
        return Complex(real * second, imaginary * second);
    }

    Complex operator / (Complex const &second)
    {
        std::cout << (real * second.real + imaginary * second.imaginary) << std::endl;
        std::cout << (second.real * second.real) << std::endl;
         std::cout << (real * second.imaginary - imaginary * second.real)
         / (second.real * second.real + second.imaginary * second.imaginary) << std::endl;
        return Complex((real * second.real + imaginary * second.imaginary)
         / (second.real * second.real + second.imaginary * second.imaginary)
        , (real * second.imaginary - imaginary * second.real)
         / (second.real * second.real + second.imaginary * second.imaginary));
    }
    Complex operator / (T const &second)
    {
        return Complex(real / second, imaginary / second);
    }

    T realPart() const
    {
        return real;
    }

    T imaginaryPart() const
    {
        return imaginary;
    }

private:
    void reverse()
    {
        T const abs = real * real + imaginary * imaginary;
        real /= abs;
        imaginary /= abs;
        imaginary *= -1;
    }

    T real;
    T imaginary;
};

