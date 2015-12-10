#pragma once

template <class T>
class Complex
{
public:
    Complex() : real(), imaginary() {};
    Complex(T real) : real(real), imaginary() {};
    Complex(T real, T imaginary) : real(real), imaginary(imaginary) {};

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

    T realPart() const;
    T imaginaryPart() const;
    T abs() const;
    T arg() const;

private:
    T real;
    T imaginary;
};
