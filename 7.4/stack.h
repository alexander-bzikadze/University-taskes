#pragma once

template <typename T>
class Stack
{
public:
    Stack();
    ~Stack();
    void push(T value);
    T pop();
    T top() const;

private:
    class StackElement
    {
    public:
        StackElement(T value, StackElement * next);
        ~StackElement();
        T getValue() const;
        StackElement * getNext() const;

    private:
        T value;
        StackElement * next;
    };
    StackElement * head;
};

template <typename T>
Stack<T>::Stack()
    :head(nullptr)
    {}

template <typename T>
Stack<T>::~Stack()
{
    while (head != nullptr)
    {
        pop();
    }
}

template <typename T>
void Stack<T>::push(T value)
{
    // std::cout << '1';
    StackElement * newElement = new StackElement(value, head);
    head = newElement;
}

template <typename T>
T Stack<T>::pop()
{
    T returnedValue = 0;
    if (head != nullptr)
    {
        StackElement * deletedElement = head;
        returnedValue = head->getValue();
        head = head->getNext();
        delete deletedElement;
        deletedElement = nullptr;
    }
    return returnedValue;
}

template <typename T>
T Stack<T>::top() const
{
    if (head != nullptr)
    {
        return head->getValue();
    }
    return 0;
}

template <typename T>
Stack<T>::StackElement::StackElement(T value, StackElement * next)
{
    this->value = value;
    this->next = next;
}

template <typename T>
Stack<T>::StackElement::~StackElement()
{

}

template <typename T>
T Stack<T>::StackElement::getValue() const
{
    return value;
}

template <typename T>
typename Stack<T>::StackElement * Stack<T>::StackElement::getNext() const
{
    return next;
}