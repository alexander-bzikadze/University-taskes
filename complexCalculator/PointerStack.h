#pragma once
#include "IStack.h"

template<typename T>
class PointerStack : public IStack<T>
{
public:
    PointerStack() : head(nullptr) {}
    
    ~PointerStack()
    {
        while (head != nullptr)
        {
            pop();
        }
    }

    void push(T value)
    {
        PointerStackElement *newElement = new PointerStackElement(value, head);
        head = newElement;
    }

    T pop()
    {
        if (head == nullptr)
        {
            return T();
        }
        else
        {
            PointerStackElement *lastElement = head->getNext();
            T returnValue = head->getValue();
            delete head;
            head = lastElement;
            return returnValue;
        }
    }

    T top() const
    {
        return head->getValue();
    }

private:
    /// Internal class for representing stack element.
    class PointerStackElement 
    {
    public:
        PointerStackElement(T value, PointerStackElement *next)
            : value(value), next(next)
        {
        }

        ~PointerStackElement()
        {
        }

        T getValue() const
        {
            return value;
        }

        PointerStack *getNext() const
        {
            return next;
        }

    private:
        T value;
        PointerStackElement *next;
    };
    PointerStackElement *head;
};