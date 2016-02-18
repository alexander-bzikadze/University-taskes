#include <iostream>

// #include "merge.h"
#include "list.h"

using namespace std;

List * mergeList(bool command, List * list)
{
    List * subList = splitList(list);
    if (sizeList(list) > 1)
    {
        list = mergeList(command, list);
    }
    if (sizeList(subList) > 1)
    {
        subList = mergeList(command, subList);
    }
    // seeAllList(list);
    // std::cout << '!' << std::endl;
    // seeAllList(subList);
    // std::cout << std::endl;
    return merge(list, subList, command);
}

int main()
{
    List * list = createList();
    bool command = false;
    cout << "Use 1 to sort by name and 0 to sort by number." << endl;
    cin >> command;
    if (inputList(list))
    {
        std::cout << "Error!";
        return 1;
    }
    list = mergeList(command, list);
    cout << "The sorted list is:" << endl;
    seeAllList(list);
    return 0;
}