#include "tree.h"

Tree::Node::Node(int value)
    : value(value), leftChild(nullptr), rigthChild(nullptr)
{
}

Tree::Node::~Node()
{

}

int Tree::Node::getValue() const
{
    return value;
}

Tree::Node * Tree::Node::getRightChild() const
{
    return rigthChild;
}

Tree::Node * Tree::Node::getLeftChild() const
{
    return leftChild;
}

void Tree::Node::addChild(int value, bool isRight)
{
    Node * newNode = new Node(value);
    if (isRight)
    {
        rigthChild = newNode;
    }
    else
    {
        leftChild = newNode;
    }
}

void Tree::Node::showNode() const
{
    if (leftChild != nullptr)
    {
        leftChild->showNode();
    }
    std::cout << ' ' << value;
    if (rigthChild != nullptr)
    {
        rigthChild->showNode();
    }
}

// void Tree::Node::changeValue(int const &value)
// {
//     this->value = value;
// }

void Tree::Node::deleteRoot()
{
    if (rigthChild != nullptr)
    {
        rigthChild->deleteRoot();
        delete rigthChild;
    }
    if (leftChild != nullptr)
    {
        leftChild->deleteRoot();
        delete leftChild;
    }
}

Tree::Tree()
    : root(nullptr)
{
}

Tree::~Tree()
{
    if (root == nullptr)
    {
        return;
    }
    root->deleteRoot();
    delete root;
    root = nullptr;
}

void Tree::show() const
{
    if (root != nullptr)
    {
        root->showNode();
    }
    else
    {
        std::cout << "Deleted";
    }
}

void Tree::add(int value)
{
    Node * currentNode = root;
    if (currentNode == nullptr)
    {
        Node * newNode = new Node(value);
        root = newNode;
    }
    else while (true)
    {
        if (currentNode->getValue() == value)
        {
            break;
        }
        if (currentNode->getValue() < value)
        {
            if (currentNode->getRightChild() == nullptr)
            {
                currentNode->addChild(value, true);
                break;
            }
            currentNode = currentNode->getRightChild();
        }
        else
        {
            if (currentNode->getLeftChild() == nullptr)
            {
                currentNode->addChild(value, false);
                break;
            }
            currentNode = currentNode->getLeftChild();
        }
    }
}

bool Tree::check(int value) const
{
    bool result = false;
    if (root == nullptr)
    {
        // std::cout << '!';
        return result;
    }
    Node * currentNode = root;
    while (true)
    {
        // std::cout << currentNode->getValue() << std::endl;
        if (currentNode->getValue() == value)
        {
            result = true;
        }
        else if (currentNode->getValue() < value)
        {
            if (currentNode->getRightChild() != nullptr)
            {
                currentNode = currentNode->getRightChild();
                continue;
            }
        }
        else if (currentNode->getValue() > value)
        {
            if (currentNode->getLeftChild() != nullptr)
            {
                currentNode = currentNode->getLeftChild();
                continue;
            }
        }
        return result;
    }
}

void Tree::Node::felicide(bool isRight)
{
    // std::cout << value << std::endl;
    Node * currentNode = nullptr;
    if (isRight)
    {
        currentNode = rigthChild;
    }
    else
    {
        currentNode = leftChild;
    }
    if (currentNode->rigthChild != nullptr)
    {
        if (currentNode->rigthChild->leftChild != nullptr)
        {
            currentNode = currentNode->rigthChild;
            while (currentNode->leftChild->leftChild != nullptr)
            {
                currentNode = currentNode->leftChild;
            }
            rigthChild->value = currentNode->leftChild->value;
            currentNode->felicide(false);
        }
        else
        {
            rigthChild->value = currentNode->rigthChild->value;
            currentNode->felicide(true);
        }
    }
    else if (currentNode->leftChild != nullptr)
    {
        if (currentNode->leftChild->rigthChild != nullptr)
        {
            currentNode = currentNode->leftChild;
            while (currentNode->rigthChild->rigthChild != nullptr)
            {
                currentNode = currentNode->rigthChild;
            }
            rigthChild->value = currentNode->rigthChild->value;
            currentNode->felicide(true);
        }
        else
        {
            leftChild->value = currentNode->leftChild->value;
            currentNode->felicide(false);
        }
    }
    else
    {
        delete currentNode;
        if (isRight)
        {
            rigthChild = nullptr;
        }
        else
        {
            leftChild = nullptr;
        }
    }
}

void Tree::fatherInLaw()
{
    Node * fatherInLaw = new Node(0);
    fatherInLaw->adoptRoot(root);
    fatherInLaw->felicide(true);
    root = fatherInLaw->getRightChild();
    delete fatherInLaw;
    fatherInLaw = nullptr;
}

void Tree::Node::adoptRoot(Node * root)
{
    rigthChild = root;
}

void Tree::deleteValue(int value)
{
    // std::cout << value << std::endl;
    if (!check(value)) //will also be checked in dialogue, but still
    {
        return;
    }
    if (root->getLeftChild() == nullptr && root->getRightChild() == nullptr)
    {
        delete root;
        root = nullptr;
        return;
    }
    if (root->getValue() == value)
    {
        fatherInLaw();
        return;
    }
    Node * currentNode = root;
    while (true)
    {
        // std::cout << currentNode->getValue() << std::endl;
        if (currentNode->getValue() < value)
        {
            if (currentNode->getRightChild() != nullptr)
            {
                if (currentNode->getRightChild()->getValue() == value)
                {
                    // std::cout << currentNode->getValue() << std::endl;
                    currentNode->felicide(true);
                    break;
                }
                currentNode = currentNode->getRightChild();
            }
        }
        else
        {
            // std::cout << '!' << currentNode->getLeftChild()->getValue() << std::endl;
            if (currentNode->getLeftChild() != nullptr)
            {
                if (currentNode->getLeftChild()->getValue() == value)
                {
                    currentNode->felicide(false);
                    break;
                }
                currentNode = currentNode->getLeftChild();
            }
        }
    }
}