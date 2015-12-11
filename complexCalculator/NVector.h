#pragma once

template <class T, class... Args>
class NVector
{
public:
    NVector(T first, Args... args) : first(first), args(args) {};

private:
    T first;
    NVector<Args...> args...;
};

template <class T>
class NVector
{

};