// #include "stack.h"

// Stack::Stack()
//     :head(nullptr)
//     {}

// Stack::~Stack()
// {
//     while (head != nullptr)
//     {
//         pop();
//     }
// }

// void Stack::push(int value)
// {
//     // std::cout << '1';
//     StackElement * newElement = new StackElement(value, head);
//     head = newElement;
// }

// int Stack::pop()
// {
//     int returnedValue = 0;
//     if (head != nullptr)
//     {
//         StackElement * deletedElement = head;
//         returnedValue = head->getValue();
//         head = head->getNext();
//         delete deletedElement;
//         deletedElement = nullptr;
//     }
//     return returnedValue;
// }

// int Stack::top() const
// {
//     if (head != nullptr)
//     {
//         return head->getValue();
//     }
//     return 0;
// }

// Stack::StackElement::StackElement(int value, StackElement * next)
// {
//     this->value = value;
//     this->next = next;
// }

// Stack::StackElement::~StackElement()
// {

// }

// int Stack::StackElement::getValue() const
// {
//     return value;
// }

// Stack::StackElement * Stack::StackElement::getNext() const
// {
//     return next;
// }