#include "tree.h"

// bool isOperation(char character)
// {
//     return character == '+' || character == '-' ||
//          character == '*' || character == '/';
// }

int count(char operation, int firstValue, int secondValue)
{
    if (operation == '+')
    {
        return firstValue + secondValue;
    }
    if (operation == '-')
    {
        return firstValue - secondValue;
    }
    if (operation == '*')
    {
        return firstValue * secondValue;
    }
    return firstValue / secondValue;
}

Tree::TreeElement::TreeElement(int value)
    : value(value), operation(0), left(nullptr), right(nullptr)
{
}

Tree::TreeElement::TreeElement(char operation)
    : operation(operation), value(0), left(nullptr), right(nullptr)
{
}

Tree::TreeElement::~TreeElement()
{
    operation = 0;
    value = 0;
    left = nullptr;
    right = nullptr;
}

void Tree::TreeElement::setChild(bool isRight, TreeElement * newChild)
{
    if (isRight)
    {
        right = newChild;
    }
    else
    {
        left = newChild;
    }
}

void Tree::TreeElement::deleteChild(bool isRight)
{
    TreeElement * deletedChild = nullptr;
    if (isRight)
    {
        deletedChild = right;
        right = nullptr;
    }
    else
    {
        deletedChild = left;
        left = nullptr;
    }
    if (deletedChild != nullptr)
    {
        if (deletedChild->hasSons())
        {
            deletedChild->deleteChild(true);
            deletedChild->deleteChild(false);
        }
    }
    delete deletedChild;
    deletedChild = nullptr;
}

bool Tree::TreeElement::hasSons()
{
    return left != nullptr || right != nullptr;
}

int Tree::TreeElement::getValue()
{
    if (hasSons())
    {
        int rightValue = 0;
        if (right != nullptr)
        {
            rightValue = right->getValue();
        }
        int leftValue = 0;
        if (left != nullptr)
        {
            leftValue = left->getValue();
        }
        value = count(operation, leftValue, rightValue);
    }
    return value;
}

char * Tree::TreeElement::build(char * input)
{
    int i = 0;
    const short leftAndRight = 2;
    for (int isRight = 0; isRight < leftAndRight; isRight++)
    {
        if (input[i] == '(')
        {
            ++i;
            TreeElement * newChild = new TreeElement(input[i]);
            i += 2;
            input = newChild->build(input + i);
            i = 1;
            setChild(static_cast<bool>(isRight), newChild);
            newChild = nullptr;
        }
        else
        {
            int number = 0;
            if (input[i] == '-')
            {
                ++i;
                number -= input[i] - '0';
                ++i;
            }
            while (input[i] >= '0' && input[i] <='9')
            {
                number *= 10;
                if (number >= 0)
                {
                number += input[i] - '0';
                }
                else
                {
                    number -= input[i] - '0';
                } 
                ++i;
            }
            TreeElement * newChild = new TreeElement(number);
            setChild(static_cast<bool>(isRight), newChild);
            newChild = nullptr;
            ++i;
        }
    }
    return input + i;
}

void Tree::TreeElement::print()
{
    if (!hasSons())
    {
        cout << value << ' ';
        return;
    }
    cout << "( " << operation << ' '; 
    left->print();
    right->print();
    cout << " ) ";
}

Tree::Tree()
{
    root = nullptr;
}

Tree::~Tree()
{
    if (root == nullptr)
    {
        return;
    }
    root->deleteChild(false);
    root->deleteChild(true);
    delete root;
    root = nullptr;
}

void Tree::build(char * string)
{
    root = new TreeElement(string[1]);
    root->build(string + 3);
}

void Tree::print()
{
    if (root != nullptr)
    {
        root->print();
        // cout << endl;
    }
}

int Tree::getValue()
{
    if (root != nullptr)
    {
        root->getValue();
    }
}