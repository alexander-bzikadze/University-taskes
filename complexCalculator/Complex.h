#pragma once

template <class T>
class Complex
{
public:
    Complex();
    Complex(T real, T imaginary) : real(real), imaginary(imaginary) {};

    Complex operator + (Complex second);
    Complex operator - (Complex second);
    Complex operator * (Complex second);
    Complex operator / (Complex second);

    T realPart() const;
    T imaginaryPart() const;
    T abs() const;
    T arg() const;

private:
    T real;
    T imaginary;
};



