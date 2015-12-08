#pragma once

class Stack
{
public:
    Stack();
    ~Stack();
    void push(int value);
    int pop();
    int top() const;

private:
    class StackElement
    {
    public:
        StackElement(int value, StackElement * next);
        ~StackElement();
        int getValue() const;
        StackElement * getNext() const;

    private:
        int value = 0;
        StackElement * next = nullptr;
    };
    StackElement * head = nullptr;
};